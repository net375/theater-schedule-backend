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
        //public List<string> Role { get; set; }
        //public List<string> FirstName { get; set; }
        //public List<string> LastName { get; set; }
    }
}


