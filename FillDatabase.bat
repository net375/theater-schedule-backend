sqlcmd -f 1251 -v FullScriptDir="%CD%" -S COMPUTER -d TheaterDatabase -U sa -P admin -i TheaterDatabase\TestData\FillByTestData.sql
pause