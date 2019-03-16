using System.Collections.Generic;
using TheaterSchedule.DAL.Models;
namespace TheaterSchedule.DAL.Interfaces
{
    public interface IPerfomanceRepository
    {
        List<PerformanceDataModel> GetPerformanceTitlesAndImages(string languageCode);
    }
}
