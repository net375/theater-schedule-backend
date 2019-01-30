using System;
using System.Collections.Generic;
using System.Linq;
using TheaterSchedule.DAL;
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

        public IEnumerable<Schedule> GetListPerformancesByDateRange(DateTime startRange, DateTime endRange)
        {
            List<Schedule> listPerfomances = uow.Schedule.GetWithInclude(p => p.performance).ToList();
            List<Schedule> listPerfomancesDateRange = new List<Schedule>();

            foreach (var perfomance in listPerfomances)
            {
                if (perfomance.Beginning >= startRange && perfomance.Beginning <= endRange)
                {
                    listPerfomancesDateRange.Add(perfomance);
                }
            }

            return listPerfomancesDateRange;
        }
    }
}
