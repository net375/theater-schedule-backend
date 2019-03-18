using System;

namespace TheaterSchedule.BLL.DTO
{
    public class ScheduleDTOBase
    {
        public int PerformanceId { get; set; }
        public DateTime Beginning { get; set; }
        public string Title { get; set; }
    }
}
