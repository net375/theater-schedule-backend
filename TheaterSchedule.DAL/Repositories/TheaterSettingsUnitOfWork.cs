using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.DAL.Contexts;
using TheaterSchedule.DAL.Interfaces;

namespace TheaterSchedule.DAL.Repositories
{
   public class TheaterSettingsUnitOfWork :ISettingsUnitOfWork
    {
        private TheaterScheduleContext db;
        private SettingsRepository settingsRepository;

        public TheaterSettingsUnitOfWork(TheaterScheduleContext context)
        {
            db = context;
        }

        public ISettingsRepository Settings
        {
            get
            {
                if (settingsRepository == null)
                    settingsRepository = new SettingsRepository(db);
                return settingsRepository;
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
