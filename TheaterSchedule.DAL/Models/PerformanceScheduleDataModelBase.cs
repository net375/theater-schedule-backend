using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterSchedule.DAL.Models
{
    public class PerformanceScheduleDataModelBase
    {
        public DateTime Day { get; set; }
        public List<TimeLink> TimeLinkList { get; set; }
    }

    public class TimeLink
    {
        public DateTime Time { get; set; }
        public string Link { get; set; }
    }

}
