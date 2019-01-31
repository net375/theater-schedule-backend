using System;
using System.Collections.Generic;
using System.Linq;
using TheaterSchedule.DAL;
using TheaterSchedule.DAL.Entities;
using TheaterSchedule.DAL.Interfaces;

namespace TheaterSchedule.BLL
{
    public class ScheduleServices : IScheduleServices
    {
        private ITheaterScheduleUnitOfWork uow;

        public ScheduleServices(ITheaterScheduleUnitOfWork repo)
        {
            uow = repo;
        }

        public IEnumerable<Schedule> GetListPerformancesByDateRange(DateTime? startDate, DateTime? endDate)
        {
            IEnumerable<Schedule> listPerfomances = uow.Schedule
                .GetWithInclude(p => p.Performance)
                .Where(p => p.Beginning >= startDate && p.Beginning <= endDate);
            return listPerfomances;
        }
    }
}
