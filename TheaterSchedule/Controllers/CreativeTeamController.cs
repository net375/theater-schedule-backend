using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;

namespace TheaterSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreativeTeamController : Controller
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
