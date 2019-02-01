using System;
using System.Collections.Generic;

namespace TheaterSchedule.DAL.Entities
{
    public partial class GalleryImage
    {
        public int GalleryImageId { get; set; }
        public byte[] Image { get; set; }
        public int? PerformanceId { get; set; }

        public virtual Performance Performance { get; set; }
    }
}
