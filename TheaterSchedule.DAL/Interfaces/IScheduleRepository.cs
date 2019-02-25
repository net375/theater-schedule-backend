using System;
using System.Collections.Generic;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IScheduleRepository
    {
        IEnumerable<ScheduleDataModel> GetListPerformancesByDateRange(
            string languageCode,
            DateTime? startDate, DateTime? endDate);
    }
}
