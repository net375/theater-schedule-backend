using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.BLL.DTO;
using System;
using Microsoft.AspNetCore.Http;

namespace TheaterSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceScheduleController : ControllerBase
    {
        private IPerformanceScheduleService performanceScheduleService;
        public PerformanceScheduleController(IPerformanceScheduleService performanceScheduleService)
        {
            this.performanceScheduleService = performanceScheduleService;
        }

        /// <summary>
        /// Loads particular performance schedule, main image, price, age and duration range from lvivpuppet.com
        /// </summary>
        /// <param name="id">particular performance id</param>
        /// <returns>a schedule list, main image, price, age and duration range for appropriate performance</returns>
        /// <response code="200">Returns a full info about appropriate performance</response>
        /// <response code="400">If url which you are sending is not valid</response>
        /// <response code="404">If the information about performance is null</response> 
        [HttpGet("{id}", Name = "Get")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PerformanceScheduleDTO> Get(int id)
        {
            try
            {
                PerformanceScheduleDTO performanceSchedule = performanceScheduleService.LoadScheduleData(id);

                if (performanceSchedule == null)
                    return NotFound();

                return StatusCode(200, performanceSchedule);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
                
    }
}
