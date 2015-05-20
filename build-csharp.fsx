// include Fake lib
#r "packages/FAKE/tools/FakeLib.dll"

open Fake
open OpenCoverHelper
open Fake.ReportGeneratorHelper
open System

// Properties
let buildDir = "./artifacts/"

// Targets
Target "Clean" (fun _ ->
    CleanDirs [buildDir]
)

Target "RestorePackages" (fun _ -> 
     "src/csharp-kata.sln"
        |> RestoreMSSolutionPackages (fun p ->
            { p with Sources = "https://www.nuget.org/api/v2/" :: p.Sources ;Retries = 4; OutputPath= "./src/packages" })
 )

Target "Build" (fun _ ->
   !! "src/**/*.csproj"
     |> MSBuildRelease buildDir "Build"
     |> Log "AppBuild-Output: "
)

Target "Test" (fun _ ->
    let opencoverPath = findToolFolderInSubPath "OpenCover.Console.exe" (currentDirectory @@ "tools" @@ "OpenCover") @@ "OpenCover.Console.exe"
    let nunitPath = findToolFolderInSubPath "nunit-console.exe" (currentDirectory @@ "tools" @@ "Nunit") @@ "nunit-console.exe"
    let nunitOrangePath = findToolFolderInSubPath "NUnitOrange.exe" (currentDirectory @@ "tools" @@ "NUnitOrange") @@ "NUnitOrange.exe"
    let reportGenPath = findToolFolderInSubPath "ReportGenerator.exe" (currentDirectory @@ "tools" @@ "ReportGenerator") @@ "ReportGenerator.exe"
   
    let assemblies = !! (buildDir + "*.dll") --"nunit.framework.*" |> separated " "
    
    traceImportant assemblies
    OpenCover (fun p -> { p with 
                              ExePath = opencoverPath ;
                              TestRunnerExePath = nunitPath; 
                              Output = (buildDir + "opencover.xml"); 
                              Register = RegisterType.RegisterUser ; 
                              Filter = "+[*]* -[*]*Tests";
                              OptionalArguments = "-excludebyattribute:System.Diagnostics.Conditional" })  
         (assemblies + " /config:Release /noshadow /xml:"+buildDir+"TestResults.xml /framework:net-4.5")
    ReportGenerator (fun p -> { p with ExePath = reportGenPath; TargetDir = (buildDir + "coverage/") }) [ (buildDir + "opencover.xml") ]

    ExecProcess (fun info ->
            info.FileName <- nunitOrangePath; info.WorkingDirectory <- buildDir; info.Arguments <- "TestResults.xml TestResults.html") (TimeSpan.FromMinutes 5.0)
            |> ignore

)

Target "Watch" (fun _ ->
    use watcher = !! "src/**/*.cs" |> WatchChanges (fun changes -> 
        tracefn "%A" changes
        Run "Test"
    )

    System.Console.ReadLine() |> ignore //Needed to keep FAKE from exiting

    watcher.Dispose() // Use to stop the watch from elsewhere, ie another task.
)

Target "Default" (fun _ ->
    trace "All done :)"
)

// Dependencies
"Clean"
  ==> "RestorePackages"
  ==> "Build"
//  ==> "Test-Cover"
  ==> "Test"
  ==> "Default"

// start build
RunTargetOrDefault "Default"