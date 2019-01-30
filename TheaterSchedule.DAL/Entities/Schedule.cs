using System;
using TheaterSchedule.DAL.Entities;

namespace TheaterSchedule.DAL
{
    public class Schedule
    {
        public int ScheduleId;
        public string Title;
        public DateTime Beginning;
        public int PerfomanceId;
        public Performance performance;
    }
}
