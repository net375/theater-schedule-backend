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

        [HttpGet("{phoneId}/{languageCode}/GetInfo")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        public ActionResult<PerformanceDetailsBaseDTO> GetInfo(
            string phoneId, string languageCode, int id)
        {
            try
            {
                PerformanceDetailsBaseDTO performanceDetails = performanceDetailsService
                    .LoadPerformanceDetails(phoneId, languageCode, id);

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
