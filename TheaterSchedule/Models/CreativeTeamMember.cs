using System.Collections.Generic;

namespace TheaterSchedule.Models
{
    public class CreativeTeamMember
    {
        public CreativeTeamMember()
        {
            PerformanceCreativeTeamMember = new HashSet<PerformanceCreativeTeamMember>();
        }

        public int CreativeTeamMemberId { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<PerformanceCreativeTeamMember> PerformanceCreativeTeamMember { get; set; }
    }
}
