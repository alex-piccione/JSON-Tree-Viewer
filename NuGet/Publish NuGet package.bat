@echo OFF
rem http://docs.nuget.org/ndocs/tools/nuget.exe-cli-reference#push

rem nuget setApikey GUID -source https://www.nuget.org/api/v2/package
nuget push *.nupkg -Source https://www.nuget.org/api/v2/package

echo "NuGet package pushed"

