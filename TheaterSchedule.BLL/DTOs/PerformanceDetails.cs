using System.Collections.Generic;

namespace TheaterSchedule.BLL.DTO
{
    public class PerformanceDetails: PerformanceDetailsBase
    {
        public byte [] MainImage { get; set; }
        public IEnumerable<byte []> GalleryImage { get; set; }
    }
}


