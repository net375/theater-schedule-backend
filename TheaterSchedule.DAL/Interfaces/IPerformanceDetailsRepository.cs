using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IPerformanceDetailsRepository
    {
        PerformanceDetailsDataModel GetInformationAboutPerformanceScreen(string phoneId, string languageCode, int id );
    }
}
