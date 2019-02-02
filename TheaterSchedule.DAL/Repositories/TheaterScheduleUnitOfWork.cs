using System;
using TheaterSchedule.DAL.Contexts;
using TheaterSchedule.DAL.Interfaces;

namespace TheaterSchedule.DAL.Repositories
{
    public class TheaterScheduleUnitOfWork : ITheaterScheduleUnitOfWork
    {
        private TheaterScheduleContext db;
        private ScheduleRepository scheduleRepository;
        private PerformanceRepository performanceRepository;
        private GalleryImageRepository galleryImageRepository;

        public TheaterScheduleUnitOfWork(TheaterScheduleContext context)
        {
            db = context;
        }

        public IScheduleRepository Schedule
        {
            get
            {
                if (scheduleRepository == null)
                    scheduleRepository = new ScheduleRepository(db);
                return scheduleRepository;
            }
        }

        public IPerformanceRepository Performances
        {
            get
            {
                if (performanceRepository == null)
                    performanceRepository = new PerformanceRepository(db);
                return performanceRepository;
            }
        }

        public IGalleryImageRepository GalleryImages
        {
            get
            {
                if (galleryImageRepository == null)
                    galleryImageRepository = new GalleryImageRepository(db);
                return galleryImageRepository;
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
