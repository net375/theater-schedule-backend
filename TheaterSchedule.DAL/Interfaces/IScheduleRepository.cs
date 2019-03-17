using System;
using System.Collections.Generic;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IScheduleRepository
    {
        IEnumerable<ScheduleDataModelBase> GetListPerformancesByDateRange(
            string languageCode,
            DateTime? startDate, DateTime? endDate);
    }
}
