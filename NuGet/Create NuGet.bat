
@echo OFF
rem http://docs.nuget.org/ndocs/tools/nuget.exe-cli-reference#pack

nuget pack "..\JSON Viewer\JSON Viewer.csproj" -Prop Configuration=Release -build -IncludeReferencedProjects -symbols 
rem this command create an EMPTY package !!!
rem nuget pack "NuGet.nuspec" -build -Prop Configuration=Release -IncludeReferencedProjects -symbols

echo "NuGet package created"