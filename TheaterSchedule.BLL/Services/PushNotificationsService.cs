using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using TheaterSchedule.BLL.Helpers;
using System;

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
            var cacheProvider = new CacheProvider(memoryCache);

            //performances
            List<PerformanceDataModel> performancesWp =
                cacheProvider.GetAndSave(
                    () => Constants.PerformancesCacheKey + "uk",
                    () => perfomanceRepository.GetPerformanceTitlesAndImages("uk"));

            //schedule
            IEnumerable<ScheduleDataModelBase> scheduleWp =
                cacheProvider.GetAndSave(
                    () => Constants.ScheduleCacheKey + "uk",
                    () => scheduleRepository.GetListPerformancesByDateRange("uk", DateTime.Now, null));

            //statements above need to be changed when cache preload is implemented

            IEnumerable<PushTokenDataModelPartial> pushTokensPartial = pushTokenRepository.GetAllPushTokensToSendNotifications();

            List<PushTokenDataModel> pushTokens =
                (from partialInfo in pushTokensPartial
                 join performance in performancesWp on partialInfo.PerformanceId equals performance.PerformanceId
                 join schedule in scheduleWp on performance.PerformanceId equals schedule.PerformanceId

                // where (schedule.Beginning.Day == (DateTime.Today.AddDays(partialInfo.Frequency).Day)
                  //       && (schedule.PerformanceId == partialInfo.PerformanceId))

                 select new PushTokenDataModel
                 {
                     Token = partialInfo.Token,
                     LanguageCode = partialInfo.LanguageCode,
                     ImageUrl = performance.MainImageUrl,
                     Title= performance.Title
                 })
                 .Distinct(new PushTokenDataModelComparer()) //select distinct push tokens in order not to send several notifications
                 .ToList();

            List<PushNotificationDTO> reqBody = (pushTokens.Select(p =>
                new PushNotificationDTO
                {
                    To = p.Token,
                    Title = p.LanguageCode == "en" ? "Lviv Puppet Theater" : "Львівський театр ляльок",
                    Body = p.LanguageCode == "en" ?
                        $"{p.Title} coming soon" : $"{p.Title} скоро на сцені",
                    Icon =$"{p.ImageUrl}",
                    Color = "#9984d4"
                })).ToList();
            
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

    internal class PushTokenDataModelComparer : IEqualityComparer<PushTokenDataModel>
    {
        public bool Equals(PushTokenDataModel x, PushTokenDataModel y)
        {
            if (string.Equals(x.Token, y.Token))
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(PushTokenDataModel obj)
        {
            return obj.Token.GetHashCode();
        }
    }
}
