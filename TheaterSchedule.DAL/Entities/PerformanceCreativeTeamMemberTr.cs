using System;
using System.Collections.Generic;

namespace TheaterSchedule.DAL.Entities
{
    public partial class PerformanceCreativeTeamMemberTr
    {
        public int PerformanceCreativeTeamMemberTrid { get; set; }
        public string Role { get; set; }
        public int LanguageId { get; set; }
        public int PerformanceCreativeTeamMemberId { get; set; }

        public virtual Language Language { get; set; }
        public virtual PerformanceCreativeTeamMember PerformanceCreativeTeamMember { get; set; }
    }
}
