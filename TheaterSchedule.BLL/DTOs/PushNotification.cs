using Newtonsoft.Json;

namespace TheaterSchedule.BLL.DTO
{
    public class PushNotification
    {
        [JsonProperty("to")]
        public string To { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
    }
}
