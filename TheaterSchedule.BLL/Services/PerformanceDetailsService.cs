using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace TheaterSchedule.BLL.Services
{
    public class PerformanceDetailsService : IPerformanceDetailsService
    {
        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private IPerformanceDetailsService performanceDetailsService;
        private IMemoryCache memoryCache;
        public PerformanceDetailsDTOBase performanceDetailsRequest;

        public PerformanceDetailsService(
            ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork,
            IPerformanceDetailsService performanceDetailsService, 
            IMemoryCache memoryCache )
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.performanceDetailsService = performanceDetailsService;
            this.memoryCache = memoryCache;
        }

        public PerformanceDetailsDTOBase LoadPerformanceDetails(
            string phoneId, string languageCode, int performanceId)
        {
            string memoryCacheKey = GetCacheKey(languageCode, performanceId);
            if ( !memoryCache.TryGetValue(memoryCache, out performanceDetailsRequest) )
            {
                performanceDetailsRequest = performanceDetailsService.LoadPerformanceDetails(
                        phoneId, languageCode, performanceId);
                memoryCache.Set(memoryCacheKey, performanceDetailsRequest);
            }
            return performanceDetailsRequest;
        }
        private string GetCacheKey( string languageCode, int id )
        {
            return $"PerformanceDetails {languageCode} {id}";
        }
    }
}
