using System.Collections.Generic;

namespace TheaterSchedule.DAL.Models
{
    public class PerformanceDetailsDataModel : PerformanceDetailsDataModelBase
    {
        public byte[] MainImage { get; set; }
        public bool IsChecked { get; set; }
        public IEnumerable<TeamMember> TeamMember { get; set; }
        public IEnumerable<string> HashTag { get; set; }
        public IEnumerable<byte[]> GalleryImage { get; set; }
    }
}