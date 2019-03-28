using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
using TheaterSchedule.BLL.Helpers;

namespace TheaterSchedule.BLL.Services
{
    public class ScheduleServiceWp : IScheduleService
    {
        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private IScheduleRepository scheduleRepositoryWp;
        private IMemoryCache memoryCache;

        public ScheduleServiceWp(ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork,
            IScheduleRepository scheduleRepositoryWp, IMemoryCache memoryCache)
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.scheduleRepositoryWp = scheduleRepositoryWp;
            this.memoryCache = memoryCache;
        }

        public IEnumerable<ScheduleBaseDTO> FilterByDate(
            string languageCode,
            DateTime? startDate, DateTime? endDate)
        {
            var cacheProvider = new CacheProvider(memoryCache);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ScheduleBaseDTO, ScheduleWpDTO>())
                .CreateMapper();

            IEnumerable<ScheduleDataModelBase> schedule =
                cacheProvider.GetAndSave(
                    () => Constants.ScheduleCacheKey + languageCode,
                    () => scheduleRepositoryWp.GetListPerformancesByDateRange(languageCode, startDate, endDate));

            IEnumerable<ScheduleWpDTO> scheduleList =
                mapper.Map<IEnumerable<ScheduleDataModelBase>, List<ScheduleWpDTO>>(schedule);

            return scheduleList = scheduleList.Where(s => (!startDate.HasValue || s.Beginning >= startDate) && (!endDate.HasValue || s.Beginning <= endDate));
        }
    }
}
