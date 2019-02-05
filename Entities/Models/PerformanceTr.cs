using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Performance_TR")]
    public partial class PerformanceTr
    {
        [Column("Performance_TRId")]
        public int PerformanceTrid { get; set; }
        [Required]
        [StringLength(30)]
        public string Title { get; set; }
        public int LanguageId { get; set; }
        [Column(TypeName = "text")]
        public string Description { get; set; }
        public int PerformanceId { get; set; }

        [ForeignKey("LanguageId")]
        [InverseProperty("PerformanceTr")]
        public virtual Language Language { get; set; }
        [ForeignKey("PerformanceId")]
        [InverseProperty("PerformanceTr")]
        public virtual Performance Performance { get; set; }
    }
}
