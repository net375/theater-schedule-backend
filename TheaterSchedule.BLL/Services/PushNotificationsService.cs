using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.DTOs;
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
                    () => scheduleRepository.GetListPerformancesByDateRange("uk", DateTime.Now));

            //statements above need to be changed when cache preload is implemented

            IEnumerable<PushTokenDataModelPartial> pushTokensPartial = pushTokenRepository.GetAllPushTokensToSendNotifications();

            List<PushTokenDataModel> pushTokens =
                (from partialInfo in pushTokensPartial
                 join performance in performancesWp on partialInfo.PerformanceId equals performance.PerformanceId
                 join schedule in scheduleWp on performance.PerformanceId equals schedule.PerformanceId

                 where (schedule.Beginning.Day == (DateTime.Today.AddDays(partialInfo.Frequency).Day)
                        && (schedule.PerformanceId == partialInfo.PerformanceId))

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
        
        public void SendPostPushNotification(AdminsPostDTO post)
        {
            if (post.IsPersonal)
            {
                int userId = post.ToUserId.GetValueOrDefault();
                IEnumerable<PushTokenDataModelPartial> pushTokenById = pushTokenRepository.GetPushTokenByAccountId(userId);
                var pushNotificationById =
                    (from partialInfo in pushTokenById
                     select new PushTokenDataModel
                     {
                         Token = partialInfo.Token,
                         LanguageCode = partialInfo.LanguageCode,

                     }).ToList();
               List<PushNotificationDTO> reqBody = (pushNotificationById.Select(p =>
               new PushNotificationDTO
               {
                   To = p.Token,
                   Title = p.LanguageCode == "en" ? "New message" : "Нове повідомлення",
                   Body = p.LanguageCode == "en" ?
                       "You got new private message" : "Вам прийшло нове приватне повідомлення",
                   Color = "#9984d4",
                   Icon= "../img/logo.png"
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



            else
            {
                IEnumerable<PushTokenDataModelPartial> allPushTokens = pushTokenRepository.GetAllPushTokensWithoutPerformances();
                var allTokens= (from pushToken in allPushTokens
                 select new PushTokenDataModel
                 {
                     Token = pushToken.Token,
                     LanguageCode = pushToken.LanguageCode,

                 }).ToList();
                List<PushNotificationDTO> reqBody = (allTokens.Select(p =>
               new PushNotificationDTO
               {
                   To = p.Token,
                   Title = p.LanguageCode == "en" ? "New message" : "Нове повідомлення",
                   Body = p.LanguageCode == "en" ?
                       "You got new public message" : "Вам прийшло нове спільне повідомлення",
                   Color = "#9984d4",
                   Icon = "../img/logo.png"
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
