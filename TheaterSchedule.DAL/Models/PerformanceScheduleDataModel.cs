using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.DAL.Models;
namespace TheaterSchedule.DAL.Models
{
    public class PerformanceScheduleDataModel
    {
        public List<PerformanceScheduleDataModelBase> ScheduleList { get; set; }
        public int PerformanceId { get; set; }
        public string Title { get; set; }
        public string MainImage { get; set; }
        public string Price { get; set; }
        public int Age { get; set; }
        public int Duration { get; set; }
    }
}
