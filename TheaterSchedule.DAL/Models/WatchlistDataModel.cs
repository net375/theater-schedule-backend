using System;

namespace TheaterSchedule.DAL.Models
{
    public class WatchlistDataModel
    {
        public int ScheduleId { get; set; }
        public DateTime Beginning { get; set; }
        public string Title { get; set; }
        public byte[] MainImage { get; set; }
    }
}
