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

let runRestorePackages() = 
    "src/fsharp-kata.sln"
        |> RestoreMSSolutionPackages (fun p ->
            { p with Sources = "https://www.nuget.org/api/v2/" :: p.Sources ;Retries = 4; OutputPath= "./src/packages" })

Target "RestorePackages" (fun _ -> 
    runRestorePackages()
 )

let runBuild() = 
   !! "src/**/*.fsproj"
     |> MSBuildRelease buildDir "Build"
     |> Log "AppBuild-Output: "

Target "Build" (fun _ ->
    runBuild()
)

let runtest () =
    let opencoverPath = findToolFolderInSubPath "OpenCover.Console.exe" (currentDirectory @@ "packages/OpenCover/tools" ) @@ "OpenCover.Console.exe"
    let nunitPath = findToolFolderInSubPath "nunit3-console.exe" (currentDirectory @@ "packages/NUnit.Console/tools") @@ "nunit3-console.exe"
    let ReportUnitPath = findToolFolderInSubPath "reportunit.exe" (currentDirectory @@ "packages/ReportUnit/tools" @@ "reportunit") @@ "reportunit.exe"
    let reportGenPath = findToolFolderInSubPath "ReportGenerator.exe" (currentDirectory @@ "packages/ReportGenerator/tools" ) @@ "ReportGenerator.exe"
   
   
    let assemblies = !! (buildDir + "*.dll") --"nunit.framework.*" |> separated " "
    
    traceImportant assemblies
    OpenCover (fun p -> { p with 
                              ExePath = opencoverPath ;
                              TestRunnerExePath = nunitPath; 
                              Output = (buildDir + "opencover.xml"); 
                              Register = RegisterType.RegisterUser ; 
                              Filter = "+[*]* -[*]*Tests";
                              OptionalArguments = "-excludebyattribute:System.Diagnostics.Conditional" })  
         (assemblies + " --out="+buildDir+"TestResults-fsharp.xml")
    //ReportGenerator (fun p -> { p with ExePath = reportGenPath; TargetDir = (buildDir + "coverage/") }) [ (buildDir + "opencover.xml") ]

    ExecProcess (fun info ->
            info.FileName <- ReportUnitPath; info.WorkingDirectory <- buildDir; info.Arguments <- "TestResults-fsharp.xml TestResults-fsharp.html") (TimeSpan.FromMinutes 5.0)
            |> ignore


Target "Test" (fun _ ->
    runtest()
)

Target "Watch" (fun _ ->
    use watcher = !! "src/**/*.fs" |> WatchChanges (fun changes -> 
        tracefn "%A" changes
        runRestorePackages()
        runBuild()
        runtest()
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