sqlcmd -f 1251 -v FullScriptDir="%CD%" server ="COMPUTER" -i TheaterDatabase\TestData\FillByTestData.sql
pause