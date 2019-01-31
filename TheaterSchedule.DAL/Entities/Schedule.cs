using System;
using System.ComponentModel.DataAnnotations;

namespace TheaterSchedule.DAL.Entities
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }
        public string Title { get; set; }
        public DateTime Beginning { get; set; }
        public int PerfomanceId { get; set; }
        public Performance performance { get; set; }
    }
}
