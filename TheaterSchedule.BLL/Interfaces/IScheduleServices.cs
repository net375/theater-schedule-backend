using System;
using System.Collections.Generic;
using TheaterSchedule.DAL;

namespace TheaterSchedule.BLL
{
    public interface IScheduleServices
    {
        IEnumerable<Schedule> GetListPerformancesByDateRange(DateTime? startDate, DateTime? endDate);
    }
}
