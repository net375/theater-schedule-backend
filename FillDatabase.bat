sqlcmd -f 1251 -S DESKTOP-F0OVMC9\SQLEXPRESS -v FullScriptDir="%CD%" -i TheaterDatabase\TestData\FillByTestData.sql
pause