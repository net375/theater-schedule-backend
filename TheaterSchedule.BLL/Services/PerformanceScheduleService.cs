using TheaterSchedule.DAL.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.BLL.Helpers;

namespace TheaterSchedule.BLL.Services
{
    public class PerformanceScheduleService : IPerformanceScheduleService
    {
        private IPerformanceScheduleRepository performanceScheduleRepository;
        private IMemoryCache memoryCache;

        public PerformanceScheduleService(IPerformanceScheduleRepository performanceScheduleRepository, IMemoryCache memoryCache)
        {
            this.performanceScheduleRepository = performanceScheduleRepository;
            this.memoryCache = memoryCache;
        }

        public string GetMemoryCacheKey(int performanceId)
        {
            return "Performance_" + performanceId.ToString();
        }

        public PerformanceScheduleDTO LoadScheduleData(int performanceId)
        {
            PerformanceScheduleDTO performanceScheduleRequest = null;

            CacheProvider cacheProvider = new CacheProvider(memoryCache);

            var scheduleDataModel = cacheProvider.GetAndSave(() => GetMemoryCacheKey(performanceId), () => performanceScheduleRepository.GetPerfomanceScheduleInfo(performanceId).Result);

            performanceScheduleRequest = new PerformanceScheduleDTO()
            {
                PerformanceId = scheduleDataModel.PerformanceId,
                Title = scheduleDataModel.Title,
                MainImage = scheduleDataModel.MainImage,
                ScheduleList = scheduleDataModel.ScheduleList,
                Age = scheduleDataModel.Age,
                Duration = scheduleDataModel.Duration,
                Price = scheduleDataModel.Price,
            };

            return performanceScheduleRequest;
        }
    }
}
