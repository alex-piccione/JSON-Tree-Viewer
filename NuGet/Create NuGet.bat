
@echo OFF
rem http://docs.nuget.org/ndocs/tools/nuget.exe-cli-reference#pack
rem Note. nuget.exe should exists in this directory or in PATH

rem move previous packages in "old" directory
if not exist "old" mkdir "old"
move /y "*.nupkg" "old"


nuget pack "..\JSON Viewer\JSON Viewer.csproj" -Prop Configuration=Release -build -IncludeReferencedProjects -symbols 
rem this command create an EMPTY package !!!
rem nuget pack "NuGet.nuspec" -build -Prop Configuration=Release -IncludeReferencedProjects -symbols

echo "NuGet package created"