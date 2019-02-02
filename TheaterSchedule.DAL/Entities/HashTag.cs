using System;
using System.Collections.Generic;

namespace TheaterSchedule.DAL.Entities
{
    public partial class HashTag
    {
        public HashTag()
        {
            HashTagPerformance = new HashSet<HashTagPerformance>();
            HashTagTr = new HashSet<HashTagTr>();
        }

        public int HashTagId { get; set; }

        public virtual ICollection<HashTagPerformance> HashTagPerformance { get; set; }
        public virtual ICollection<HashTagTr> HashTagTr { get; set; }
    }
}
