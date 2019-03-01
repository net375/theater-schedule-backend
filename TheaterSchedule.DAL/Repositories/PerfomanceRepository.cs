using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TheaterSchedule.DAL.Models;
using Entities.Models;
using TheaterSchedule.DAL.Interfaces;
using System.Threading.Tasks;

namespace TheaterSchedule.DAL.Repositories
{
    public class PerfomanceRepository : IPerfomanceRepository
    {
        TheaterDatabaseContext db;
        public PerfomanceRepository(TheaterDatabaseContext db)
        {
            this.db = db;
        }

        public List<PerformanceDataModel> GetPerformanceTitlesAndImages(string languageCode)
        {
            int languageId = db.Language.Where(a => a.LanguageCode == languageCode)
                .Select(a => a.LanguageId).FirstOrDefault();

            List<PerformanceDataModel> result = db.PerformanceTr.Where(lang => lang.LanguageId == languageId).Join(db.Performance,
                perfdetails => perfdetails.PerformanceId,
                performance => performance.PerformanceId,
                (perfdetails, performance) => new PerformanceDataModel
                {
                    Title = perfdetails.Title,
                    MainImage = performance.MainImage,
                    PerformanceId = performance.PerformanceId

                }).ToList();
            return result;
        }


        Task<IEnumerable<PerformanceDataModel>> IPerfomanceRepository.GetPerformanceTitlesAndImagesAsync(string languageCode)
        {
            throw new NotImplementedException();
        }
    }
}
