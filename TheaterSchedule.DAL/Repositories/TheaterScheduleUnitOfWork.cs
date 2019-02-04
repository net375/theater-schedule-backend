using System;
using TheaterSchedule.DAL.Contexts;
using TheaterSchedule.DAL.Interfaces;

namespace TheaterSchedule.DAL.Repositories
{
    public class TheaterScheduleUnitOfWork : ITheaterScheduleUnitOfWork
    {
        private TheaterScheduleContext db;
       
        public TheaterScheduleUnitOfWork(TheaterScheduleContext context)
        {
            db = context;
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
