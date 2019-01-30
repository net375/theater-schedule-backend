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

        public IEnumerable<Performance> GetAll()
        {
            IEnumerable<Performance> performances = db.Perfomances;

            if (performances.Count() == 0)
            {
                throw new ArgumentNullException($"GetAll method PerformanceRepository received a null argument!");
            }

            return performances;
        }

        public Performance Get(int id)
        {
            Performance performance = db.Perfomances.Find(id);

            if (performance == null)
            {
                throw new ArgumentNullException($"Get method PerformanceRepository received a null argument!");
            }

            return performance;
        }

        public void Create(Performance performance)
        {
            if (performance == null)
            {
                throw new ArgumentNullException($"Create method PerformanceRepository received a null argument!");
            }

            db.Perfomances.Add(performance);
        }

        public void Update(Performance performance)
        {
            if (performance == null)
            {
                throw new ArgumentNullException($"Update method PerformanceRepository received a null argument!");
            }

            db.Entry(performance).State = EntityState.Modified;
        }

        public IEnumerable<Performance> Find(Func<Performance, bool> predicate)
        {
            IEnumerable<Performance> performances = db.Perfomances.Where(predicate).ToList();

            if (performances.Count() == 0)
            {
                throw new ArgumentNullException($"Find method PerformanceRepository received a null argument!");
            }

            return performances;
        }

        public void Delete(int id)
        {
            Performance performance = db.Perfomances.Find(id);

            if (performance == null)
            {
                throw new ArgumentNullException($"Get method PerformanceRepository received a null argument!");
            }
            else
                db.Perfomances.Remove(performance);
        }

        public IEnumerable<Performance> GetWithInclude(params Expression<Func<Performance, object>>[] includeProperties)
        {
            IEnumerable<Performance> performances = Include(includeProperties).ToList();

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
