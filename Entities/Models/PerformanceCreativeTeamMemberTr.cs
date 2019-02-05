using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("PerformanceCreativeTeamMember_TR")]
    public partial class PerformanceCreativeTeamMemberTr
    {
        [Column("PerformanceCreativeTeamMember_TRId")]
        public int PerformanceCreativeTeamMemberTrid { get; set; }
        [Required]
        [StringLength(30)]
        public string Role { get; set; }
        public int LanguageId { get; set; }
        public int PerformanceCreativeTeamMemberId { get; set; }

        [ForeignKey("LanguageId")]
        [InverseProperty("PerformanceCreativeTeamMemberTr")]
        public virtual Language Language { get; set; }
        public virtual PerformanceCreativeTeamMember PerformanceCreativeTeamMember { get; set; }
    }
}
