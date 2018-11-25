dotnet test .\test\CampanhaBrinquedo.Test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=../../coverage/
cd ./coverage
reportgenerator "-reports:.\coverage.cobertura.xml" "-targetdir:."
if [%1]==[] goto openCoverage

:openCoverage
start index.htm
exit 1

cd ..