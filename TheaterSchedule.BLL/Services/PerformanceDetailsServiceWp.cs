using Microsoft.Extensions.Caching.Memory;
using System.Linq;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.BLL.Services
{
    public class PerformanceDetailsServiceWp: IPerformanceDetailsService
    {
        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private IPerformanceDetailsRepository performanceDetailsRepository;
        private ITagRepository tagRepository;
        private ICreativeTeamRepository creativeTeamRepository;
        private IIsCheckedPerformanceRepository isCheckedPerformanceRepository;
        private IMemoryCache memoryCache;
        private PerformanceDetailsDTOBase performanceDetailsRequest;

        public PerformanceDetailsServiceWp( 
            ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork,
            IPerformanceDetailsRepository performanceDetailsRepository, 
            ITagRepository tagRepository, 
            ICreativeTeamRepository creativeTeamRepository,
            IIsCheckedPerformanceRepository isCheckedPerformanceRepository,
            IMemoryCache memoryCache )
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.performanceDetailsRepository = performanceDetailsRepository;
            this.tagRepository = tagRepository;
            this.creativeTeamRepository = creativeTeamRepository;
            this.isCheckedPerformanceRepository = isCheckedPerformanceRepository;
            this.memoryCache = memoryCache;
        }

        public PerformanceDetailsDTOBase LoadPerformanceDetails( string phoneId, string languageCode, int performanceId )
        {
            string memoryCacheKey = GetCacheKey( languageCode, performanceId );
            if ( !memoryCache.TryGetValue( memoryCacheKey, out performanceDetailsRequest ) )
            {
                var performance = performanceDetailsRepository
                    .GetInformationAboutPerformance( phoneId, languageCode, performanceId ) 
                    as PerformanceDetailsDataModelWp;

                var tags = tagRepository.GetTagsByPerformanceId( performanceId ).Result;
                var creativeTeam = creativeTeamRepository.GetCreativeTeam( languageCode, performanceId );
                var isChecked = isCheckedPerformanceRepository.IsChecked( phoneId, performanceId );

                performanceDetailsRequest = new PerformanceDetailsDTOWp()
                {
                    Title = performance.Title,
                    Duration = performance.Duration,
                    MinimumAge = performance.MinimumAge,
                    MinPrice = performance.MinPrice,
                    MaxPrice = performance.MaxPrice,
                    Description = performance.Description,
                    MainImage = performance.MainImage,
                    GalleryImage = performance.GalleryImage,
                    IsChecked = isChecked,
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
                memoryCache.Set( memoryCacheKey, performanceDetailsRequest );
            }
            return performanceDetailsRequest;
        }

        private string GetCacheKey( string languageCode, int id )
        {
            return $"PerformanceDetails {languageCode} {id}";
        }
    }
}
