using System.Collections.Generic;

namespace TheaterSchedule.DAL.Models
{
    public class PerformanceDetailsDataModelWp: PerformanceDetailsDataModelBase
    {
        public string MainImage { get; set; }
        public IEnumerable<string> GalleryImage { get; set; }

    }
}
