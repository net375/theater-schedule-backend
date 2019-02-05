cd TheaterSchedule
copy appsettings.json D:\Repository\theater-schedule-backend\Entities
cd ..\Entities
dotnet ef dbcontext scaffold name=TheaterConnectionString Microsoft.EntityFrameworkCore.SqlServer -o Models -f --data-annotations -f
del /f appsettings.json, appsettings.Development.json
cd..
pause