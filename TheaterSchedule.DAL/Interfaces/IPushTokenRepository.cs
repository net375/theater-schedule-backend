using System.Collections.Generic;
using Entities.Models;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IPushTokenRepository
    {
        void Add(PushToken pushToken);
        IEnumerable<PushTokenDataModelPartial> GetAllPushTokensToSendNotifications();
    }
}
