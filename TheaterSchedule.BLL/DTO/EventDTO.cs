using System;

namespace TheaterSchedule.BLL.DTO
{
    public class EventDTO
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string Type { get; set; }
        public byte[] Image { get; set; }
        public DateTime Date { get; set; }
    }
}
