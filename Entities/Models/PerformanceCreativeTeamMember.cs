using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public partial class PerformanceCreativeTeamMember
    {
        public PerformanceCreativeTeamMember()
        {
            PerformanceCreativeTeamMemberTr = new HashSet<PerformanceCreativeTeamMemberTr>();
        }

        public int PerformanceCreativeTeamMemberId { get; set; }
        public int CreativeTeamMemberId { get; set; }
        public int PerformanceId { get; set; }

        [ForeignKey("CreativeTeamMemberId")]
        [InverseProperty("PerformanceCreativeTeamMember")]
        public virtual CreativeTeamMember CreativeTeamMember { get; set; }
        [ForeignKey("PerformanceId")]
        [InverseProperty("PerformanceCreativeTeamMember")]
        public virtual Performance Performance { get; set; }
        public virtual ICollection<PerformanceCreativeTeamMemberTr> PerformanceCreativeTeamMemberTr { get; set; }
    }
}
