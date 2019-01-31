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
    public class PerformanceRepository : IRepository<Performance>
    {
        private TheaterScheduleContext db;

        public PerformanceRepository(TheaterScheduleContext context)
        {
            this.db = context;
        }

        public IEnumerable<Performance> GetWithInclude(params Expression<Func<Performance, object>>[] includeProperties)
        {
            IEnumerable<Performance> performances = Include(includeProperties);

            if (performances.Count() == 0)
            {
                throw new ArgumentNullException($"GetWithInclude method PerformanceRepository received a null argument!");
            }

            return performances;
        }

        private IQueryable<Performance> Include(params Expression<Func<Performance, object>>[] includeProperties)
        {
            IQueryable<Performance> query = db.Perfomances.AsNoTracking();
            IQueryable<Performance> performances = includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            if (performances.Count() == 0)
            {
                throw new ArgumentNullException($"Include method PerformanceRepository received a null argument!");
            }

            return performances;
        }
    }
}
