using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.BLL.Services
{
    public class ScheduleServiceWp : IScheduleServiceWp
    {
        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private IScheduleRepositoryWp scheduleRepositoryWp;

        public ScheduleServiceWp(ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork,
            IScheduleRepositoryWp scheduleRepositoryWp)
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.scheduleRepositoryWp = scheduleRepositoryWp;
        }

        public IEnumerable<ScheduleDTOWp> FilterByDate(
            string languageCode,
            DateTime? startDate, DateTime? endDate)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ScheduleDataModelWp, ScheduleDTOWp>())
                .CreateMapper();
            return mapper.Map<IEnumerable<ScheduleDataModelWp>, List<ScheduleDTOWp>>(
                scheduleRepositoryWp.GetPerformancesByDateRange(languageCode, startDate, endDate));
        }
    }
}
