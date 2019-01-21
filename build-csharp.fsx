#r "paket:
nuget Fake.DotNet.Cli
nuget Fake.Core.Target //"
#load "./.fake/build-csharp.fsx/intellisense.fsx"

open Fake.Core
open Fake.IO
//open Fake.DotNet

// Properties
let buildDir = "./build/"


// *** Define Targets ***
Target.create "Clean" (fun _ ->
  Shell.cleanDir buildDir
)

Target.create "Build" (fun _ ->
  Trace.log " --- Building the app --- "
  //DotNet.
)

Target.create "Deploy" (fun _ ->
  Trace.log " --- Deploying app --- "
)

open Fake.Core.TargetOperators

// *** Define Dependencies ***
"Clean"
  ==> "Build"
  ==> "Deploy"

// *** Start Build ***
Target.runOrDefault "Deploy"

// // Properties
// let settings = { 
//     buildDir = "./artifacts/"; 
//     solution = "src/csharp-kata.sln"; 
//     projetsPattern = "src/**/*.csproj"; 
//     watchFilePattern = "src/**/*.cs"; 
//     coverageAssembliesPattern = "*-csharp.dll";
// }

// SetUpBuild settings
// // start build
// RunTargetOrDefault "Default"