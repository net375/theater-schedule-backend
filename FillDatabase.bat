sqlcmd -f 65001 -v FullScriptDir="%CD%" -S DESKTOP-F0OVMC9\SQLEXPRESS -d TheaterDatabase -U sa -P 1111 -i TheaterDatabase\TestData\FillByTestData.sql
pause