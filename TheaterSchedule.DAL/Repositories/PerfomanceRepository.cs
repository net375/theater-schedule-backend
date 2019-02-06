using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Entities.Models;
using TheaterSchedule.DAL.Interfaces;

namespace TheaterSchedule.DAL.Repositories
{
    public class PerfomanceRepository: IPerfomanceRepository 
    {
        TheaterDatabaseContext db;
        public PerfomanceRepository(TheaterDatabaseContext db)
        {
            this.db = db;
        }
       

        public IEnumerable<byte[]> GetAllPerformanceImages()
        {
            return db.Performance.Select(a=>a.MainImage);
        }

        public List<Performance> GetPerformanceTitles(int settingsId)
        {
            int languageId = db.Settings.Where(a => a.SettingsId == settingsId).Select(c => c.LanguageId).First();
            var definedPerformances = db.Performance.Include(a => a.PerformanceTr);
            List<string> selectedTitles = new List<string>();
            List<Performance> selectedPerformances = db.Performance.Include(k => k.PerformanceTr).Where(t => t.PerformanceTr.Any(P => P.LanguageId == languageId)).ToList();
            //foreach(var performance in definedPerformances)
            //{
            //    foreach(var perfDetails in performance.PerformanceTr)
            //    {
            //        var Selectedtitle = perfDetails.Title;
            //        selectedTitles.Add(perfDetails.Title);
            //    }
            //}

            return selectedPerformances;
        }

        
    }
}
