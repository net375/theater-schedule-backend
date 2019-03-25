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
