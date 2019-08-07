using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using System;

namespace TheaterSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceDetailsController : Controller
    {
        IPerformanceDetailsService performanceDetailsService;

        public PerformanceDetailsController(
            IPerformanceDetailsService performanceDetailsService)
        {
            this.performanceDetailsService = performanceDetailsService;
        }
        /// <summary>
        /// Loads details information about performance  from lvivpuppet.com
        /// </summary>
        /// <param name="Accountid"></param>
        /// <param name="languageCode"></param>
        /// <param name="performanceId"></param>
        /// <returns>a details information about performance from lvivpuppet.com</returns>
        /// <response code="200">Returns a details information about performance of appropriate language</response>
        /// <response code="400">If url which you are sending is not valid</response>
        /// <response code="404">If the information about performance is null</response> 
        [HttpGet("{Accountid}/{languageCode}/GetInfo/{performanceId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        public ActionResult<PerformanceDetailsBaseDTO> GetInfo(
            string Accountid, string languageCode, int performanceId)
        {
            try
            {
                PerformanceDetailsBaseDTO performanceDetails = performanceDetailsService
                    .LoadPerformanceDetails(Accountid, languageCode, performanceId);

                if (performanceDetails == null)
                    return NotFound();
                return StatusCode(200, performanceDetails);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
