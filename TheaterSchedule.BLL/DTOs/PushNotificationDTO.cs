using Newtonsoft.Json;

namespace TheaterSchedule.BLL.DTO
{
    public class PushNotificationDTO
    {
        [JsonProperty("to")]
        public string To { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
        [JsonProperty("color")]
        public string Color { get; set; }
    }
}
