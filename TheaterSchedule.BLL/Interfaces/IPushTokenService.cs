using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IPushTokenService
    {
        void StorePushToken(string phoneId, string pushToken);
        IEnumerable<string> GetAllPushTokens();
    }
}
