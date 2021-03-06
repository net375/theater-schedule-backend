using System.Collections.Generic;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.BLL.DTO
{
    public class PerformanceScheduleDTO
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
