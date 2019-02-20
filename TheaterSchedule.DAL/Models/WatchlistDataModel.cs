using System;

namespace TheaterSchedule.DAL.Models
{
    public class WatchlistDataModel
    {
        public int PerformanceId { get; set; }
        public string Title { get; set; }
        public byte[] MainImage { get; set; }
    }
}
