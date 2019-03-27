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
        private ICacheProvider cacheProvider;

        public PerformanceScheduleService(IPerformanceScheduleRepository performanceScheduleRepository, ICacheProvider cacheProvider)
        {
            this.performanceScheduleRepository = performanceScheduleRepository;
            this.cacheProvider = cacheProvider;
        }

        public string GetMemoryCacheKey(int performanceId)
        {
            return $"Performance_{performanceId}";
        }

        public PerformanceScheduleDTO LoadScheduleData(int performanceId)
        {
            PerformanceScheduleDTO performanceScheduleRequest = null;

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
