using System.Collections.Generic;

namespace TheaterSchedule.BLL.DTO
{
    public class PerformanceDetailsDTOWp: PerformanceDetailsDTOBase
    {
        public string MainImage { get; set; }
        public IEnumerable<string> GalleryImage { get; set; }
    }
}


