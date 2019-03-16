using System.Collections.Generic;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IPushTokenService
    {
        void StorePushToken(string phoneId, string pushToken);
        IEnumerable<string> GetAllPushTokens();
    }
}
