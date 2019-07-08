using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
using TheaterSchedule.BLL.Helpers;

namespace TheaterSchedule.BLL.Services
{
    public class PerformanceDetailsServiceWp : IPerformanceDetailsService
    {
        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private IPerformanceDetailsRepository performanceDetailsRepository;
        private ITagRepository tagRepository;
        private ICreativeTeamRepository creativeTeamRepository;
        private IIsCheckedPerformanceRepository isCheckedPerformanceRepository;
        private IMemoryCache memoryCache;
        private PerformanceDetailsBaseDTO performanceDetailsRequest;

        public PerformanceDetailsServiceWp(
            ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork,
            IPerformanceDetailsRepository performanceDetailsRepository,
            ITagRepository tagRepository,
            ICreativeTeamRepository creativeTeamRepository,
            IIsCheckedPerformanceRepository isCheckedPerformanceRepository,
            IMemoryCache memoryCache)
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.performanceDetailsRepository = performanceDetailsRepository;
            this.tagRepository = tagRepository;
            this.creativeTeamRepository = creativeTeamRepository;
            this.isCheckedPerformanceRepository = isCheckedPerformanceRepository;
            this.memoryCache = memoryCache;
        }

        public PerformanceDetailsBaseDTO LoadPerformanceDetails(string phoneId, string languageCode, int performanceId)
        {
            var cacheProvider = new CacheProvider(memoryCache);

            var isChecked = isCheckedPerformanceRepository.IsChecked(phoneId, performanceId);

            performanceDetailsRequest = cacheProvider.GetAndSave(
                    () => GetCacheKey(languageCode, performanceId),
                    () =>
                    {
                        var performance = performanceDetailsRepository
                            .GetInformationAboutPerformance(phoneId, languageCode, performanceId)
                            as PerformanceDetailsDataModelWp;

                        var tags = tagRepository.GetTagsByPerformanceId(performanceId).Result;
                        var creativeTeam = creativeTeamRepository.GetCreativeTeam(languageCode, performanceId);

                        performanceDetailsRequest = new PerformanceDetailsWpDTO()
                        {
                            Title = performance.Title,
                            Duration = performance.Duration,
                            MinimumAge = performance.MinimumAge,
                            MinPrice = performance.MinPrice,
                            MaxPrice = performance.MaxPrice,
                            Price = performance.Price,
                            Description = performance.Description,
                            MainImage = performance.MainImage,
                            GalleryImage = performance.GalleryImage,
                            HashTag = from tg in tags
                                      select tg,
                            TeamMember = from tm in creativeTeam
                                         select new TeamMemberDTO()
                                         {
                                             FirstName = tm.FirstName,
                                             LastName = tm.LastName,
                                             Role = tm.Role,
                                             RoleKey = tm.RoleKey,
                                         },
                        };

                        return performanceDetailsRequest;
                    });

            performanceDetailsRequest.IsChecked = isChecked;

            return performanceDetailsRequest;
        }

        private string GetCacheKey(string languageCode, int id)
        {
            return $"PerformanceDetails {languageCode} {id}";
        }
    }
}
