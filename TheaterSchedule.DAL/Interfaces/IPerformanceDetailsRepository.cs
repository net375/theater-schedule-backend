﻿
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IPerformanceDetailsRepository
    {
        PerformanceDetailsDataModelBase GetInformationAboutPerformance(string phoneId, string languageCode, int id );
    }
}
