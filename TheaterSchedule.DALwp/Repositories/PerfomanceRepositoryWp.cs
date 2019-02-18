using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DALwp.Repositories
{
    class PerfomanceRepository : IPerfomanceRepository
    {
        public List<PerformanceDataModel> GetPerformanceTitlesAndImages(string languageCode)
        {
            throw new NotImplementedException();
        }
    }
}
