dotnet test .\test\CampanhaBrinquedo.Test\ /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=../../coverage/
cd ./coverage
reportgenerator "-reports:.\coverage.opencover.xml" "-targetdir:."
cd ..
dotnet-sonarscanner begin /k:"CampanhaBrinquedo" /d:sonar.host.url="http://localhost:9000" /d:sonar.login="924abf505299fb0e55c537424932732de85ff86d" /d:sonar.cs.opencover.reportsPaths="coverage/coverage.opencover.xml" /d:sonar.test.exclusions="test/**" /v:1.0.0
dotnet build
dotnet-sonarscanner end /d:sonar.login="924abf505299fb0e55c537424932732de85ff86d"