namespace TheaterSchedule.Models
{
    public class PerformanceCreativeTeamMember
    {
        public int CreativeTeamMemberId { get; set; }
        public int PerformanceId { get; set; }
        public string Role { get; set; }

        public virtual CreativeTeamMember CreativeTeamMember { get; set; }
        public virtual Performance Performance { get; set; }
    }
}
