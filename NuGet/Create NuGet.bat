
@echo OFF
rem http://docs.nuget.org/ndocs/tools/nuget.exe-cli-reference#pack

rem nuget pack "..\JSON Viewer.csproj" -Prop Configuration=Release -IncludeReferencedProjects -symbols 
nuget pack "NuGet.nuspec" -build -Prop Configuration=Release -IncludeReferencedProjects -symbols

echo "NuGet package created"