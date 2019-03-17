using System;

namespace TheaterSchedule.DAL.Models
{
    public class ScheduleDataModelBase
    {
        public int PerformanceId { get; set; }
        public DateTime Beginning { get; set; }
        public string Title { get; set; }
    }
}
