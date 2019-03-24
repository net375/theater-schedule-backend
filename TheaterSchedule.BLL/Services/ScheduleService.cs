using AutoMapper;
using System;
using System.Collections.Generic;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.BLL.Services
{
    public class ScheduleService : IScheduleService
    {
        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private IScheduleRepository scheduleRepository;

        public ScheduleService(
            ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork, 
            IScheduleRepository scheduleRepository)
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.scheduleRepository = scheduleRepository;
        }

        public IEnumerable<ScheduleBase> FilterByDate(
            string languageCode, 
            DateTime? startDate, DateTime? endDate)
        {
            var mapper = new MapperConfiguration(cfg => 
                cfg.CreateMap<ScheduleBase, Schedule>())
                .CreateMapper();
            return mapper.Map<IEnumerable<ScheduleDataModelBase>, List<Schedule>>(
                scheduleRepository.GetListPerformancesByDateRange(
                    languageCode, startDate, endDate));
        }
    }
}
