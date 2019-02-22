using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;

namespace TheaterSchedule.Controllers
{
    public class CreativeTeamController
    {
        private ICreativeTeamService creativeTeamService;

        public CreativeTeamController( ICreativeTeamService creativeTeamService )
        {
            this.creativeTeamService = creativeTeamService;
        }

        [HttpGet( "{performanceId}" )]
        public IEnumerable<TeamMemberDTO> LoadCreativeTeam(
            int performanceId )
        {
            return creativeTeamService.LoadCreativeTeam( performanceId );
        }
    }
}
