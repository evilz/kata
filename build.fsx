// include Fake lib
#I @"C:\Users\Vincent\Documents\GITHUB\kata"
#r "packages/FAKE/tools/FakeLib.dll"

open Fake
open OpenCoverHelper
open Fake.ReportGeneratorHelper
open System

type buildSettings = {
   buildDir: string;
   solution: string;
   projetsPattern: string;
   watchFilePattern: string;
   coverageAssembliesPattern: string;
   }

let SetUpBuild (setting) =

    // Targets
    Target "Clean" (fun _ ->
        CleanDirs [setting.buildDir]
    )

    let runRestorePackages() =
        setting.solution
            |> RestoreMSSolutionPackages (fun p ->
                { p with Sources = "https://www.nuget.org/api/v2/" :: p.Sources ;Retries = 4; OutputPath= "./src/packages" })

    Target "RestorePackages" (fun _ ->
        runRestorePackages()
     )

    let runBuild() =
        let properties =
                     [
                         "Optimize", "True"
                         "DebugSymbols", "True"
                         "Configuration", "Release"
                     ]

        MSBuildDefaults <- {MSBuildDefaults with Verbosity = Some(Quiet)}

        MSBuild setting.buildDir "Build" properties [setting.solution]
        |> ignore
//       !! setting.projetsPattern
//         |> MSBuildRelease setting.buildDir "Build"
//         |> Log "AppBuild-Output: "

    Target "Build" (fun _ ->
        runBuild()
    )

    let runtest () =
        let opencoverPath = findToolFolderInSubPath "OpenCover.Console.exe" (currentDirectory @@ "packages/OpenCover/tools" ) @@ "OpenCover.Console.exe"
        let nunitPath = findToolFolderInSubPath "nunit3-console.exe" (currentDirectory @@ "packages/NUnit.Console/tools") @@ "nunit3-console.exe"
        let ReportUnitPath = findToolFolderInSubPath "reportunit.exe" (currentDirectory @@ "packages/ReportUnit/tools" @@ "reportunit") @@ "reportunit.exe"
        let reportGenPath = findToolFolderInSubPath "ReportGenerator.exe" (currentDirectory @@ "packages/ReportGenerator/tools" ) @@ "ReportGenerator.exe"

        let assemblies = !! (setting.buildDir + setting.coverageAssembliesPattern) |> separated " "

        traceImportant assemblies
        OpenCover (fun p -> { p with
                                  ExePath = opencoverPath ;
                                  TestRunnerExePath = nunitPath;
                                  Output = (setting.buildDir + "opencover.xml");
                                  Register = RegisterType.RegisterUser ;
                                  Filter = "+[*]* -[*]*Tests";
                                  OptionalArguments = "-excludebyattribute:System.Diagnostics.Conditional" })
             (assemblies + " --out="+setting.buildDir+"TestResults.xml")
        //     (assemblies + " /config:Release /noshadow /xml:"+buildDir+"TestResults.xml /framework:net-4.5")
        //ReportGenerator (fun p -> { p with ExePath = reportGenPath; TargetDir = (buildDir + "coverage/") }) [ (buildDir + "opencover.xml") ]

        ExecProcess (fun info ->
                info.FileName <- ReportUnitPath; info.WorkingDirectory <- setting.buildDir; info.Arguments <- "TestResults.xml TestResults.html") (TimeSpan.FromMinutes 5.0)
                |> ignore

        setEnvironVar "PATH" "C:\\Python34;C:\\Python34\\Scripts;%PATH%"
                |> ignore

        ExecProcess (fun info ->
                info.FileName <- "pip"; info.Arguments <- "install codecov") (TimeSpan.FromMinutes 5.0)
                |> ignore
        ExecProcess (fun info ->
                info.FileName <- "codecov"; info.Arguments <- "-f \"./artifacts/opencover.xml\"") (TimeSpan.FromMinutes 5.0)
                |> ignore


    Target "Test" (fun _ ->
        runtest()
    )

    Target "Watch" (fun _ ->
        use watcher = !! setting.watchFilePattern |> WatchChanges (fun changes ->
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


