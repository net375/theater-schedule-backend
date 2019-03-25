using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;

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
            IEnumerable<ScheduleDataModelBase> schedule = null;

            string memoryCacheKey = GetCacheKey(languageCode);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ScheduleBaseDTO, ScheduleWpDTO>())
                .CreateMapper();

            if (!memoryCache.TryGetValue(memoryCacheKey, out schedule))
            {
                schedule = scheduleRepositoryWp.GetListPerformancesByDateRange(languageCode, startDate, endDate);
                memoryCache.Set(memoryCacheKey, schedule);
            }

            IEnumerable<ScheduleWpDTO> scheduleList =
                mapper.Map<IEnumerable<ScheduleDataModelBase>, List<ScheduleWpDTO>>(schedule);

            return scheduleList = scheduleList.Where(s => (!startDate.HasValue || s.Beginning >= startDate) && (!endDate.HasValue || s.Beginning <= endDate));
        }

        private string GetCacheKey(string languageCode)
        {
            return $"Schedule {languageCode}";
        }
    }
}
