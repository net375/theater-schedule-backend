using System;
using TheaterSchedule.DAL.Interfaces;
using Entities.Models;

namespace TheaterSchedule.DAL.Repositories
{
    public class TheaterScheduleUnitOfWork : ITheaterScheduleUnitOfWork
    {
        private TheaterDatabaseContext db;
       
        public TheaterScheduleUnitOfWork(TheaterDatabaseContext context)
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
