// include Fake lib
#r "packages/FAKE/tools/FakeLib.dll"
#load "build.fsx"

open Build
open Fake

// Properties
let settings = { 
    buildDir = "./artifacts/"; 
    solution = "src/fsharp-kata.sln"; 
    projetsPattern = "src/**/*.fsproj"; 
    watchFilePattern = "src/**/*.fs"; 
    coverageAssembliesPattern = "*-fsharp.dll";
}

SetUpBuild settings
// start build
RunTargetOrDefault "Default"