// include Fake lib
#r "packages/FAKE/tools/FakeLib.dll"
#load "build.fsx"

open Build
open Fake

// Properties
let settings = { 
    buildDir = "./artifacts/"; 
    solution = "src/csharp-kata.sln"; 
    projetsPattern = "src/**/*.csproj"; 
    watchFilePattern = "src/**/*.cs"; 
    coverageAssembliesPattern = "*-csharp.dll";
}

SetUpBuild settings
// start build
RunTargetOrDefault "Default"