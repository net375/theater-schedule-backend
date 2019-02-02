using System;
using System.Collections.Generic;

namespace TheaterSchedule.DAL.Entities
{
    public partial class HashTagPerformance
    {
        public int PerformanceId { get; set; }
        public int HashTagId { get; set; }
        public int HashTagPerformanceId { get; set; }

        public virtual HashTag HashTag { get; set; }
        public virtual Performance Performance { get; set; }
    }
}
