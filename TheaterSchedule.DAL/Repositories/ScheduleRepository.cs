using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TheaterSchedule.DAL.Contexts;
using TheaterSchedule.DAL.Entities;
using TheaterSchedule.DAL.Interfaces;

namespace TheaterSchedule.DAL.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private TheaterScheduleContext db;

        public ScheduleRepository(TheaterScheduleContext context)
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

        public IEnumerable<Schedule> GetListPerformancesByDateRange(DateTime? startDate, DateTime? endDate)
        {
            IEnumerable<Schedule> listPerfomances = null;

            listPerfomances = GetWithInclude(p => p.Performance)
                .Where(p =>
                    (!endDate.HasValue && !startDate.HasValue) ||
                    (!endDate.HasValue && p.Beginning >= startDate) ||
                    (!startDate.HasValue && p.Beginning <= endDate) ||
                    (p.Beginning >= startDate && p.Beginning <= endDate)
                );

            return listPerfomances;
        }
    }
}
