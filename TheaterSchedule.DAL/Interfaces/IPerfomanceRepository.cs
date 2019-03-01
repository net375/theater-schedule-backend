using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
namespace TheaterSchedule.DAL.Interfaces
{
    public interface IPerfomanceRepository
    {   
        Task<IEnumerable<PerformanceDataModel>> GetPerformanceTitlesAndImagesAsync(string languageCode);
    }
}
