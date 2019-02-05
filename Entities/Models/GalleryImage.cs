using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public partial class GalleryImage
    {
        public int GalleryImageId { get; set; }
        [Required]
        public byte[] Image { get; set; }
        public int? PerformanceId { get; set; }

        [ForeignKey("PerformanceId")]
        [InverseProperty("GalleryImage")]
        public virtual Performance Performance { get; set; }
    }
}
