using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public partial class Performance
    {
        public Performance()
        {
            GalleryImage = new HashSet<GalleryImage>();
            HashTagPerformance = new HashSet<HashTagPerformance>();
            PerformanceCreativeTeamMember = new HashSet<PerformanceCreativeTeamMember>();
            PerformanceTr = new HashSet<PerformanceTr>();
            Schedule = new HashSet<Schedule>();
        }

        public int PerformanceId { get; set; }
        [Required]
        public byte[] MainImage { get; set; }
        public int Duration { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public int MinimumAge { get; set; }

        [InverseProperty("Performance")]
        public virtual ICollection<GalleryImage> GalleryImage { get; set; }
        [InverseProperty("Performance")]
        public virtual ICollection<HashTagPerformance> HashTagPerformance { get; set; }
        [InverseProperty("Performance")]
        public virtual ICollection<PerformanceCreativeTeamMember> PerformanceCreativeTeamMember { get; set; }
        [InverseProperty("Performance")]
        public virtual ICollection<PerformanceTr> PerformanceTr { get; set; }
        [InverseProperty("Performance")]
        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}
