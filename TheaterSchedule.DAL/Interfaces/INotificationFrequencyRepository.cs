using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface INotificationFrequencyRepository
    {
        NotificationFrequency GetNotificationFrequencyByFrequency(int frequency);
        NotificationFrequency GetNotificationFrequencyById(int id);
    }
}
