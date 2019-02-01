using System;
using System.Collections.Generic;

namespace TheaterSchedule.DAL.Entities
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

        public virtual CreativeTeamMember CreativeTeamMember { get; set; }
        public virtual Performance Performance { get; set; }
        public virtual ICollection<PerformanceCreativeTeamMemberTr> PerformanceCreativeTeamMemberTr { get; set; }
    }
}
