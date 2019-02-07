using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterSchedule.BLL.DTO
{
    public class PerformanceDTO
    {
        public byte [] MainImage { get; set; }
        public int Duration { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public int MinimumAge { get; set; }
        public string Description { get; set; }
        public IEnumerable<TeamMember> TeamMember { get; set; }


    }

    public class TeamMember
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public int id { get; set; }
    }
}


