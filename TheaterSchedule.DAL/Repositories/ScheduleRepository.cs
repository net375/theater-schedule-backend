using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TheaterSchedule.DAL.Interfaces;
using Entities.Models;

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

        public IEnumerable<Schedule> GetListPerformancesByDateRange(DateTime? startDate, DateTime? endDate)
        {
            IEnumerable<Schedule> listPerfomances = null;

            listPerfomances = GetWithInclude(p => p.Performance)
                .Where(p => (!startDate.HasValue || p.Beginning >= startDate)
                         && (!endDate.HasValue || p.Beginning <= endDate));

            return listPerfomances;
        }
    }
}
