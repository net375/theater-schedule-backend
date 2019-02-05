using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public partial class CreativeTeamMember
    {
        public CreativeTeamMember()
        {
            CreativeTeamMemberTr = new HashSet<CreativeTeamMemberTr>();
            PerformanceCreativeTeamMember = new HashSet<PerformanceCreativeTeamMember>();
        }

        public int CreativeTeamMemberId { get; set; }

        [InverseProperty("CreativeTeamMember")]
        public virtual ICollection<CreativeTeamMemberTr> CreativeTeamMemberTr { get; set; }
        [InverseProperty("CreativeTeamMember")]
        public virtual ICollection<PerformanceCreativeTeamMember> PerformanceCreativeTeamMember { get; set; }
    }
}
