using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TheaterSchedule.DAL.Interfaces;
using Entities.Models;

namespace TheaterSchedule.DAL.Repositories
{
    public class NotificationFrequencyRepository: INotificationFrequencyRepository
    {
        private TheaterDatabaseContext db;

        public NotificationFrequencyRepository(TheaterDatabaseContext context)
        {
            this.db = context;
        }

        public NotificationFrequency GetNotificationFrequencyById(int id)
        {
            return db.NotificationFrequency.SingleOrDefault(nf => nf.NotificationFrequencyId == id);
        }

        public NotificationFrequency GetNotificationFrequencyByFrequency(int frequency)
        {
            return db.NotificationFrequency.SingleOrDefault(nf => nf.Frequency == frequency);
        }
    }
}
