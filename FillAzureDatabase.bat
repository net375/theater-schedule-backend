sqlcmd -f 1251 -S theaterschedule20190209081500dbserver.database.windows.net -U dbadmin -P Lv-375.Net -v FullScriptDir="%CD%" -i TheaterDatabase\TestData\AzureData.sql
pause