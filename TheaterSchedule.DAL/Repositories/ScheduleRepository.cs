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

        public ScheduleRepository(TheaterDatabaseContext context)
        {
            this.db = context;
        }

        public IEnumerable<Schedule> GetWithInclude(params Expression<Func<Schedule, object>>[] includeProperties)
        {
            IQueryable<Schedule> query = db.Schedule.AsNoTracking();
            IQueryable<Schedule> scheduleList = includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return scheduleList;
        }

        public IEnumerable<ScheduleDataModel> GetListPerformancesByDateRange(string languageCode, DateTime? startDate, DateTime? endDate)
        {
            IEnumerable<ScheduleDataModel> listPerfomances = null;

            listPerfomances = from schedule in db.Schedule
                join performance in db.Performance on schedule.PerformanceId equals performance.PerformanceId
                join performanceTr in db.PerformanceTr on performance.PerformanceId equals performanceTr.PerformanceId
                join language in db.Language on performanceTr.LanguageId equals language.LanguageId
                where ((!startDate.HasValue || schedule.Beginning >= startDate) && (!endDate.HasValue || schedule.Beginning <= endDate) && (language.LanguageCode == languageCode))
                select new ScheduleDataModel
                {
                    ScheduleId = schedule.ScheduleId,
                    Beginning = schedule.Beginning,
                    MainImage = performance.MainImage,
                    Title = performanceTr.Title
                };

            return listPerfomances;
        }
    }
}
