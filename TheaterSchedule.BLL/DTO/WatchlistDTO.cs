using System;

namespace TheaterSchedule.BLL.DTO
{
    public class WatchlistDTO
    {
        public int ScheduleId { get; set; }
        public int PerformanceId { get; set; }
        public DateTime Beginning { get; set; }
        public string Title { get; set; }
        public byte[] MainImage { get; set; }
    }
}
