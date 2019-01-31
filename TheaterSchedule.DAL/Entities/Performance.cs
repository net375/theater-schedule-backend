using System.Collections.Generic;

namespace TheaterSchedule.DAL.Entities
{
    public class Performance
    {
        public Performance()
        {
            GalleryImage = new HashSet<GalleryImage>();
            HashTagPerformance = new HashSet<HashTagPerformance>();
            PerformanceCreativeTeamMember = new HashSet<PerformanceCreativeTeamMember>();
            Schedule = new HashSet<Schedule>();
        }

        public int PerformanceId { get; set; }
        public byte[] MainImage { get; set; }
        public int Duration { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public int MinimumAge { get; set; }
        public string Description { get; set; }

        public virtual ICollection<GalleryImage> GalleryImage { get; set; }
        public virtual ICollection<HashTagPerformance> HashTagPerformance { get; set; }
        public virtual ICollection<PerformanceCreativeTeamMember> PerformanceCreativeTeamMember { get; set; }
        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}
