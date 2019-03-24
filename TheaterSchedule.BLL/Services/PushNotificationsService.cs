using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using TheaterSchedule.BLL;

namespace TheaterSchedule.BLL.Services
{
    public class PushNotificationsService: IPushNotificationsService
    {
        private IPushTokenRepository pushTokenRepository;
        private IScheduleRepository scheduleRepository;
        private IPerfomanceRepository perfomanceRepository;
        private IMemoryCache memoryCache;

        public PushNotificationsService(IPushTokenRepository pushTokenRepository, IScheduleRepository scheduleRepository,
            IPerfomanceRepository perfomanceRepository, IMemoryCache memoryCache)
        {
            this.pushTokenRepository = pushTokenRepository;
            this.scheduleRepository = scheduleRepository;
            this.perfomanceRepository = perfomanceRepository;
            this.memoryCache = memoryCache;
        }

        public void SendPushNotification()
        {
            //performances
            List<PerformanceDataModel> performancesWp = null;

            string performanceMemoryCacheKey = Constants.PerformancesCacheKey + "uk";

            if (!memoryCache.TryGetValue(performanceMemoryCacheKey, out performancesWp))
            {
                performancesWp =
                    perfomanceRepository.GetPerformanceTitlesAndImages("uk");

                memoryCache.Set(performanceMemoryCacheKey, performancesWp);
            }

            //schedule
            string scheduleMemoryCacheKey = Constants.ScheduleCacheKey + "uk";

            IEnumerable<ScheduleDataModelBase> schedule = null;

            if (!memoryCache.TryGetValue(scheduleMemoryCacheKey, out schedule))
            {
                schedule = scheduleRepository.GetListPerformancesByDateRange("uk",
                    null, null); //needs to be changed when cache preload is implemented
                memoryCache.Set(scheduleMemoryCacheKey, schedule);
            }


            PushTokenDataModel[] pushTokens = 
                pushTokenRepository.GetAllPushTokensToSendNotifications(performancesWp, schedule ).ToArray();

            PushNotificationDTO[] reqBody = Enumerable.Range(0, pushTokens.Length).Select(i =>
                new PushNotificationDTO
                {
                    To = pushTokens[i].Token,
                    Title = pushTokens[i].LanguageCode == "en" ? "Lviv Puppet Theater" : "Львівський театр ляльок",
                    Body = pushTokens[i].LanguageCode == "en" ? 
                        "The perfomances you have liked coming soon" : "Вистави, які вам сподобались, скоро в прокаті"
                }).ToArray();
            
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                client.Headers.Add("accept", "application/json");
                client.Headers.Add("accept-encoding", "gzip, deflate");
                client.Headers.Add("Content-Type", "application/json");
                client.UploadString(
                    "https://exp.host/--/api/v2/push/send", 
                    JsonConvert.SerializeObject(reqBody));
            }
        }
    }
}
