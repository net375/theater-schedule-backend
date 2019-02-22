using AutoMapper;
using System.Collections.Generic;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.BLL.Services
{
    public class CreativeTeamService : ICreativeTeamService
    {
        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private ICreativeTeamRepository creativeTeamRepository;

        public CreativeTeamService(
            ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork,
            ICreativeTeamRepository creativeTeamRepository )
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.creativeTeamRepository = creativeTeamRepository;
        }

        public IEnumerable<TeamMemberDTO> LoadCreativeTeam(
            int performanceId )
        {
            return new MapperConfiguration(
                    cfg => cfg.CreateMap<TeamMember, TeamMemberDTO>() )
                .CreateMapper()
                .Map<IEnumerable<TeamMember>, IEnumerable<TeamMemberDTO>>(
                    creativeTeamRepository.GetCreativeTeamByPerformanceId(
                        performanceId ) );
        }
    }
}
