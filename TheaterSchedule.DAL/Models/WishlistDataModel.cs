using System;

namespace TheaterSchedule.DAL.Models
{
    public class WishlistDataModel
    {
        public int PerformanceId { get; set; }
        public string Title { get; set; }
        public byte[] MainImage { get; set; }
    }
}
