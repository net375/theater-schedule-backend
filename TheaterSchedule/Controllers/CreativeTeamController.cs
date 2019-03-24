using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;

namespace TheaterSchedule.Controllers
{
    #region snippet_CreativeTeamController
    [Route("api/[controller]")]
    [ApiController]
    public class CreativeTeamController : Controller
    {

        private ICreativeTeamService creativeTeamService;
    #endregion

        public CreativeTeamController(ICreativeTeamService creativeTeamService)
        {
            this.creativeTeamService = creativeTeamService;
        }

        #region snippet_LoadCreativeTeam

        /// <summary>
        /// Loads creative team information from performance (lvivpuppet.com)
        /// </summary>
        /// <param name="languageCode"></param>
        /// <param name="performanceId"></param>
        /// <returns>A list of creativeTeam from performance</returns>
        /// <response code="200">Returns the list of creative team from performance</response>
        /// <response code="400">If url which you are sending is not valid</response>
        /// <response code="404">If the information about creative team is null</response> 
        [HttpGet("{languageCode}/{performanceId}")]
        [Obsolete]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<TeamMember>> LoadCreativeTeam(
            string languageCode, int performanceId)
        {
            try
            {
                IEnumerable<TeamMember> creativeTeam =
                    creativeTeamService.LoadCreativeTeam(languageCode, performanceId);

                if (creativeTeam == null)
                {
                    return NotFound();
                }

                return StatusCode(200, creativeTeam);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        #endregion
    }
}
