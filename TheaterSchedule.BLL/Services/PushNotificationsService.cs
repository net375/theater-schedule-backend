using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using System.Net.Http;
using System.Linq;
using Newtonsoft.Json;

namespace TheaterSchedule.BLL.Services
{
    public class PushNotificationsService: IPushNotificationsService
    {
        private IPushTokenRepository pushTokenRepository;

        public PushNotificationsService(IPushTokenRepository pushTokenRepository)
        {
            this.pushTokenRepository = pushTokenRepository;
        }

        public void SendPushNotification()
        {
            string[] pushTokens = pushTokenRepository.GetAllPushTokensToSendNotifications().ToArray();

            PushNotificationDTO[] reqBody = Enumerable.Range(0, pushTokens.Length).Select(i =>
                new PushNotificationDTO
                {
                    To = pushTokens[i],
                    Title = "Lviv Puppet Theater",
                    Body = "The perfomances you have liked coming soon",
                }).ToArray();
            
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                client.Headers.Add("accept", "application/json");
                client.Headers.Add("accept-encoding", "gzip, deflate");
                client.Headers.Add("Content-Type", "application/json");
                client.UploadString("https://exp.host/--/api/v2/push/send", JsonConvert.SerializeObject(reqBody));
            }   
        }
    }
}
