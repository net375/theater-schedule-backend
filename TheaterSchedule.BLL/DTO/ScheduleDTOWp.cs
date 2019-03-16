using System;

namespace TheaterSchedule.BLL.DTO
{
    public class ScheduleDTOWp
    {
        public int PerformanceId { get; set; }
        public string Title { get; set; }
        public string MainImage { get; set; }
        public DateTime Beginning { get; set; }
        public string redirectToTicket { get; set; }
    }
}
