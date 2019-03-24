using TheaterSchedule.DAL.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;

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

        public PerformanceSchedule LoadScheduleData(int performanceId)
        {
            PerformanceSchedule performanceScheduleRequest;
            string memoryCacheKey = "Performance_" + performanceId.ToString();
            var scheduleDataModel = performanceScheduleRepository.GetPerfomanceScheduleInfo(performanceId).Result;

            if (!memoryCache.TryGetValue(memoryCache, out performanceScheduleRequest))
            {
                performanceScheduleRequest = new PerformanceSchedule()
                {
                    PerformanceId = scheduleDataModel.PerformanceId,
                    Title = scheduleDataModel.Title,
                    MainImage = scheduleDataModel.MainImage,
                    ScheduleList = scheduleDataModel.ScheduleList,
                    Age = scheduleDataModel.Age,
                    Duration = scheduleDataModel.Duration,
                    Price = scheduleDataModel.Price,
                };
                memoryCache.Set(memoryCacheKey, performanceScheduleRequest);
            }

            return performanceScheduleRequest;
        }
    }
}
