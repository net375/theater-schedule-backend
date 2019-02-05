using System;
using System.Collections.Generic;
using Entities.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IScheduleRepository 
    {
        IEnumerable<Schedule> GetListPerformancesByDateRange(DateTime? startDate, DateTime? endDate);
    }
}
