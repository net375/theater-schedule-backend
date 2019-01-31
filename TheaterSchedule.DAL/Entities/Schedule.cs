using System;
using System.Collections.Generic;

namespace TheaterSchedule.DAL.Entities
{
    public class Schedule
    {
        public Schedule()
        {
            Watchlist = new HashSet<Watchlist>();
        }

        public int ScheduleId { get; set; }
        public string Title { get; set; }
        public DateTime Beginning { get; set; }
        public int PerformanceId { get; set; }

        public virtual Performance Performance { get; set; }
        public virtual ICollection<Watchlist> Watchlist { get; set; }
    }
}
