using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
using TheaterSchedule.BLL;

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

        public IEnumerable<ScheduleDTOBase> FilterByDate(
            string languageCode,
            DateTime? startDate, DateTime? endDate)
        {
            IEnumerable<ScheduleDataModelBase> schedule = null;

            string memoryCacheKey = Constants.ScheduleCacheKey + languageCode;

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ScheduleDTOBase, ScheduleDTOWp>())
                .CreateMapper();

            if (!memoryCache.TryGetValue(memoryCacheKey, out schedule))
            {
                schedule = scheduleRepositoryWp.GetListPerformancesByDateRange(languageCode, startDate, endDate);
                memoryCache.Set(memoryCacheKey, schedule);
            }

            IEnumerable<ScheduleDTOWp> scheduleList =
                mapper.Map<IEnumerable<ScheduleDataModelBase>, List<ScheduleDTOWp>>(schedule);

            return scheduleList = scheduleList.Where(s => !endDate.HasValue || s.Beginning <= endDate);
        }
    }
}
