﻿
namespace TheaterSchedule.BLL
{
    public static class Constants
    {
        public const string ConnectionString = "TheaterConnectionString";
        public const string PerformancesCacheKey = "Performances";
        public const string ScheduleCacheKey = "Schedule";
        public const double DaysToExpireRefreshToken = 3;
        public const int MinToExpireAccessToken = 10;
        public const string AuthOption = "AuthOption";
    }
}
