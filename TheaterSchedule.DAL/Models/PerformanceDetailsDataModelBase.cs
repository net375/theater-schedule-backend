namespace TheaterSchedule.DAL.Models
{
    public class PerformanceDetailsDataModelBase
    {
        public int Duration { get; set; }
        public int Price { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public int MinimumAge { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
