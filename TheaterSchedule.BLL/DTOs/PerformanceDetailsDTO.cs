using System.Collections.Generic;

namespace TheaterSchedule.BLL.DTO
{
    public class PerformanceDetailsDTO: PerformanceDetailsBaseDTO
    {
        public byte [] MainImage { get; set; }
        public IEnumerable<byte []> GalleryImage { get; set; }
    }
}


