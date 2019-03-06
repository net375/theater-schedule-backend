using AutoMapper;
using System.Linq;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
using TheaterSchedule.DALwp.Repositories;

namespace TheaterSchedule.BLL.Services
{
    public class PerformanceDetailsServiceWp: IPerformanceDetailsService
    {
        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private IPerformanceDetailsRepository performanceDetailsRepository;
        private ITagRepository tagRepository;
        private ICreativeTeamRepository creativeTeamRepository;

        public PerformanceDetailsServiceWp( ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork,
            IPerformanceDetailsRepository performanceDetailsRepository, ITagRepository tagRepository, ICreativeTeamRepository creativeTeamRepository )
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.performanceDetailsRepository = performanceDetailsRepository;
            this.tagRepository = tagRepository;
            this.creativeTeamRepository = creativeTeamRepository;
        }

        public PerformanceDetailsDTOBase LoadPerformanceDetails( string phoneId, string languageCode, int performanceId )
        {
            // TODO
            // Add isChecked perository for WishList
            var performance = performanceDetailsRepository.GetInformationAboutPerformance( phoneId, languageCode, performanceId ) as PerformanceDetailsDataModelWp;
            var tags = tagRepository.GetTagsByPerformanceId( performanceId ).Result;
            var creativeTeam = creativeTeamRepository.GetCreativeTeam( languageCode, performanceId );

            return new PerformanceDetailsDTOWp()
            {
                Title = performance.Title,
                Duration = performance.Duration,
                MinimumAge = performance.MinimumAge,
                MinPrice = performance.MinPrice,
                MaxPrice = performance.MaxPrice,
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

        }
    }
}
