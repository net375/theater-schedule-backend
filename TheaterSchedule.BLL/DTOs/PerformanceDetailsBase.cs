using System.Collections.Generic;

namespace TheaterSchedule.BLL.DTO
{
    public class PerformanceDetailsBase
    {
        public int Duration { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public int MinimumAge { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsChecked { get; set; }
        public IEnumerable<TeamMember> TeamMember { get; set; }
        public IEnumerable<string> HashTag { get; set; }
    }
}
