using System;
using System.Collections.Generic;

namespace TheaterSchedule.DAL.Entities
{
    public partial class CreativeTeamMember
    {
        public CreativeTeamMember()
        {
            CreativeTeamMemberTr = new HashSet<CreativeTeamMemberTr>();
            PerformanceCreativeTeamMember = new HashSet<PerformanceCreativeTeamMember>();
        }

        public int CreativeTeamMemberId { get; set; }

        public virtual ICollection<CreativeTeamMemberTr> CreativeTeamMemberTr { get; set; }
        public virtual ICollection<PerformanceCreativeTeamMember> PerformanceCreativeTeamMember { get; set; }
    }
}
