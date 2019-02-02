using System;
using System.Collections.Generic;
using TheaterSchedule.DAL.Entities;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IScheduleRepository : IRepositoryInclude<Schedule> // , IRepository<Schedule>
    {
        IEnumerable<Schedule> GetListPerformancesByDateRange(DateTime? startDate, DateTime? endDate);
    }
}
