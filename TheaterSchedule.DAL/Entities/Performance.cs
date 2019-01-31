using System.ComponentModel.DataAnnotations;

namespace TheaterSchedule.DAL.Entities
{
    public class Performance
    {
        [Key]
        public int PerfomanceId { get; set; }
        public int Duration { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public int MinimumAge { get; set; }
        public string Description { get; set; }
    }
}
