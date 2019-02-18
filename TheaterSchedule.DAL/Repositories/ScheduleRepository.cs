using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private TheaterDatabaseContext db;

        public ScheduleRepository( TheaterDatabaseContext context )
        {
            this.db = context;
        }

        public IEnumerable<ScheduleDataModel> GetListPerformancesByDateRange(
            string phoneId, string languageCode,
            DateTime? startDate, DateTime? endDate )
        {
            IEnumerable<ScheduleDataModel> listPerfomances = null;

            listPerfomances = from schedule in db.Schedule
                join performance in db.Performance on schedule.PerformanceId equals performance.PerformanceId
                join performanceTr in db.PerformanceTr on performance.PerformanceId equals performanceTr.PerformanceId
                join language in db.Language on performanceTr.LanguageId equals language.LanguageId
                join watchlist in db.Watchlist on schedule.ScheduleId equals watchlist.ScheduleId
                    into watchlist_join
                from w in watchlist_join.DefaultIfEmpty()
                where ( ( !startDate.HasValue || schedule.Beginning >= startDate ) && 
                        ( !endDate.HasValue || schedule.Beginning <= endDate ) && 
                        ( language.LanguageCode == languageCode ) )
                orderby schedule.Beginning
                select new ScheduleDataModel
                {
                    ScheduleId = schedule.ScheduleId,
                    PerformanceId = performance.PerformanceId,
                    Beginning = schedule.Beginning,
                    MainImage = performance.MainImage,
                    Title = performanceTr.Title,
                    IsChecked = w != null && w.Account.PhoneIdentifier == phoneId
                };

            return listPerfomances;
        }
    }
}
