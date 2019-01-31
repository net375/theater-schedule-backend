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
    public class ScheduleRepository : IRepository<Schedule>
    {
        private TheaterScheduleContext db;

        public ScheduleRepository(TheaterScheduleContext context)
        {
            this.db = context;
        }

        public IEnumerable<Schedule> GetWithInclude(params Expression<Func<Schedule, object>>[] includeProperties)
        {
            IEnumerable<Schedule> scheduleList = Include(includeProperties);

            if (scheduleList.Count() == 0)
            {
                throw new ArgumentNullException($"GetWithInclude method ScheduleRepository received a null argument!");
            }

            return scheduleList;
        }

        private IQueryable<Schedule> Include(params Expression<Func<Schedule, object>>[] includeProperties)
        {
            IQueryable<Schedule> query = db.Schedule.AsNoTracking();
            IQueryable<Schedule> scheduleList = includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            if (scheduleList.Count() == 0)
            {
                throw new ArgumentNullException($"Include method ScheduleRepository received a null argument!");
            }

            return scheduleList;
        }
    }
}
