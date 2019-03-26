using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterSchedule.DAL.Models
{
    // intended for transfer to push notification service for further joining
    public class PushTokenDataModelPartial
    {
        public int PerformanceId { get; set; }
        public string Token { get; set; }
        public string LanguageCode { get; set; }
        public int Frequency { get; set; }
    }
}
