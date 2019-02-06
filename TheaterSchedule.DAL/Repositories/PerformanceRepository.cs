using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using TheaterSchedule.DAL.Interfaces;

using TheaterSchedule.DAL.Models;
using Entities.Models;

using System.Linq;

namespace TheaterSchedule.DAL.Repositories
{
    public class PerformanceRepository : IPerformanceRepository
    {
        private TheaterDatabaseContext db;

        public PerformanceRepository( TheaterDatabaseContext context )
        {
            this.db = context;
        }

        public IEnumerable<PerformanceDataModel> GetInformationAboutPerformanceScreen( int id )
        {
            IEnumerable<PerformanceDataModel> listPerfomances = null;

            listPerfomances = from performance in db.Performance
                              join performanceTr in db.PerformanceTr on performance.PerformanceId equals performanceTr.PerformanceId
                              join language in db.Language on performanceTr.LanguageId equals language.LanguageId
                              where ((performance.PerformanceId == id) && (language.LanguageName == "Polski"))
                              select new PerformanceDataModel
                              {
                                  MainImage = performance.MainImage,
                                  MinPrice = performance.MinPrice,
                                  MaxPrice = performance.MaxPrice,
                                  MinimumAge = performance.MinimumAge,
                                  Duration = performance.Duration,
                                  Description = performanceTr.Description,
                              };
            //singleordefault

            return listPerfomances;
        }
    }
}
