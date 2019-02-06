using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
namespace TheaterSchedule.DAL.Interfaces
{
    public interface IPerfomanceRepository
    {
        List<PerformanceDataModel> GetPerformanceTitlesAndImages(string languageCode);
    }
}
