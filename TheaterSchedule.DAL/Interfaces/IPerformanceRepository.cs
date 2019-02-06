using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IPerformanceRepository
    {
        IEnumerable<PerformanceDataModel> GetInformationAboutPerformanceScreen( string languageCode, int id );
    }
}
