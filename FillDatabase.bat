sqlcmd -f 1251 -v FullScriptDir="%CD%" -S SERVERNAME -d DATABASENAME -U USERNAME -P PASSWORD -i TheaterDatabase\TestData\FillByTestData.sql
pause