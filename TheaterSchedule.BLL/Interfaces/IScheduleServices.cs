using System;
using System.Collections.Generic;
using TheaterSchedule.DAL.Entities;

namespace TheaterSchedule.BLL
{
    public interface IScheduleServices
    {
        IEnumerable<Schedule> GetListPerformancesByDateRange(DateTime? startDate, DateTime? endDate);
    }
}
