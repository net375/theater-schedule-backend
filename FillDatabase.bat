sqlcmd -f 65001 -v FullScriptDir="%CD%" -S COMPUTER -d TheaterDatabase -U sa -P admin -i TheaterDatabase\TestData\FillByTestData.sql
pause