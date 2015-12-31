@echo Off
set config=%1
if "%config%" == "" (
   set config=Release
)

set version=
if not "%PackageVersion%" == "" (
   set version=-Version %PackageVersion%
)

REM Package Restore
nuget restore BetaSeries.API.sln

REM Build Solution
"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild" BetaSeries.API.sln /p:Configuration="%config%"

REM Package
mkdir Build
mkdir Build\lib
nuget pack "BetaSeries.API.nuspec" -verbosity detailed -symbols -o Build -p Configuration=%config% %version%
copy BetaSeries.API\bin\%config%\*.dll Build\lib
copy BetaSeries.API\bin\%config%\*.pdb Build\lib
