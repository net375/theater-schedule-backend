using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("HashTag_Performance")]
    public partial class HashTagPerformance
    {
        public int PerformanceId { get; set; }
        public int HashTagId { get; set; }
        [Column("HashTagPerformanceID")]
        public int HashTagPerformanceId { get; set; }

        [ForeignKey("HashTagId")]
        [InverseProperty("HashTagPerformance")]
        public virtual HashTag HashTag { get; set; }
        [ForeignKey("PerformanceId")]
        [InverseProperty("HashTagPerformance")]
        public virtual Performance Performance { get; set; }
    }
}
