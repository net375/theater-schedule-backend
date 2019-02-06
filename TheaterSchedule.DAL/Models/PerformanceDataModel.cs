using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterSchedule.DAL.Models
{
    public class PerformanceDataModel
    {
        public byte [] MainImage { get; set; }
        public int Duration { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public int MinimumAge { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> FirstName { get; set; }
        public IEnumerable<string> LastName { get; set; }
    }
}
