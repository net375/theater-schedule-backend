cd TheaterSchedule
copy appsettings.json ..\Entities
cd ..\Entities
dotnet ef dbcontext scaffold name=TheaterConnectionString Microsoft.EntityFrameworkCore.SqlServer -o Models -f --data-annotations -f
del /f appsettings.json, appsettings.Development.json
cd..
pause