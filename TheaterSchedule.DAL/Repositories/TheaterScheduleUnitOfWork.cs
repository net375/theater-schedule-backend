using System;
using TheaterSchedule.DAL.Contexts;
using TheaterSchedule.DAL.Entities;
using TheaterSchedule.DAL.Interfaces;

namespace TheaterSchedule.DAL.Repositories
{
    public class TheaterScheduleUnitOfWork : ITheaterScheduleUnitOfWork
    {
        private TheaterScheduleContext db;
        private PerformanceRepository performanceRepository;
        private ScheduleRepository scheduleRepository;

        public TheaterScheduleUnitOfWork(TheaterScheduleContext context)
        {
            db = context;
        }
        public IRepository<Performance> Performances
        {
            get
            {
                if (performanceRepository == null)
                    performanceRepository = new PerformanceRepository(db);
                return performanceRepository;
            }
        }

        public IRepository<Schedule> Schedule
        {
            get
            {
                if (scheduleRepository == null)
                    scheduleRepository = new ScheduleRepository(db);
                return scheduleRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
