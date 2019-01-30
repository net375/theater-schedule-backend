using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TheaterSchedule.DAL.Contexts;
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

        public IEnumerable<Schedule> GetAll()
        {
            IEnumerable<Schedule> scheduleList = db.Schedule;

            if (scheduleList.Count() == 0)
            {
                throw new ArgumentNullException($"GetAll method ScheduleRepository received a null argument!");
            }

            return scheduleList;
        }

        public Schedule Get(int id)
        {
            Schedule schedule = db.Schedule.Find(id);

            if (schedule == null)
            {
                throw new ArgumentNullException($"Get method ScheduleRepository received a null argument!");
            }

            return schedule;
        }

        public void Create(Schedule schedule)
        {
            if (schedule == null)
            {
                throw new ArgumentNullException($"Create method ScheduleRepository received a null argument!");
            }

            db.Schedule.Add(schedule);
        }

        public void Update(Schedule schedule)
        {
            if (schedule == null)
            {
                throw new ArgumentNullException($"Update method ScheduleRepository received a null argument!");
            }

            db.Entry(schedule).State = EntityState.Modified;
        }

        public IEnumerable<Schedule> Find(Func<Schedule, bool> predicate)
        {
            IEnumerable<Schedule> scheduleList = db.Schedule.Where(predicate).ToList();

            if (scheduleList.Count() == 0)
            {
                throw new ArgumentNullException($"Find method ScheduleRepository received a null argument!");
            }

            return scheduleList;
        }

        public void Delete(int id)
        {
            Schedule schedule = db.Schedule.Find(id);

            if (schedule == null)
            {
                throw new ArgumentNullException($"Get method ScheduleRepository received a null argument!");
            }
            else
                db.Schedule.Remove(schedule);
        }

        public IEnumerable<Schedule> GetWithInclude(params Expression<Func<Schedule, object>>[] includeProperties)
        {
            IEnumerable<Schedule> scheduleList = Include(includeProperties).ToList();

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
