
dotnet build ./Src/csharp-kata.sln
dotnet tool install --global coverlet.console
dotnet test ./Src/csharp-kata.sln  /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput='./coverage.json'
