namespace TheaterSchedule.DAL.Models
{
    public class PerformanceDataModel
    {
        public string Title { get; set; }
        public byte[] MainImage { get; set; }
        public string MainImageUrl { get; set; }
        public int PerformanceId { get; set; }       
    }
}
