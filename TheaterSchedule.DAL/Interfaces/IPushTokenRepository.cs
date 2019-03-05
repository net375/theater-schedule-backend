using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IPushTokenRepository
    {
        void Add(PushToken pushToken);
        IEnumerable<string> GetAllPushTokensToSendNotifications();
    }
}
