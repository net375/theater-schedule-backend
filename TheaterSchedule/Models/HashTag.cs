using System.Collections.Generic;

namespace TheaterSchedule.Models
{
    public class HashTag
    {
        public HashTag()
        {
            HashTagPerformance = new HashSet<HashTagPerformance>();
        }

        public int HashTagId { get; set; }
        public string Tag { get; set; }

        public virtual ICollection<HashTagPerformance> HashTagPerformance { get; set; }
    }
}
