using System.Collections.Generic;

namespace TheaterSchedule.DAL.Models
{
    public class PerformanceDetailsDataModel
    {
        public byte [] MainImage { get; set; }
        public string MainImageWp { get; set; }
        public int Duration { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public int MinimumAge { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsChecked { get; set; }
        public IEnumerable<TeamMember> TeamMember { get; set; }        
        public IEnumerable<string> HashTag { get; set; }
        public IEnumerable<byte []> GalleryImage { get; set; }
        public IEnumerable<string> GalleryImageWp { get; set; }
        public IEnumerable<int> Tags { get; set; }
    }
}
