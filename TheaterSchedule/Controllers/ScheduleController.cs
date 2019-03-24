using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using Microsoft.AspNetCore.Http;

namespace TheaterSchedule.Controllers
{
    #region snippet_ScheduleController

    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : Controller
    {
        private IScheduleService service;

        #endregion

        public ScheduleController(IScheduleService scheduleService)
        {
            service = scheduleService;
        }

        #region snippet_FilterByDate

        /// <summary>
        /// Loads schedule performances from lvivpuppet.com
        /// </summary>
        /// <param name="languageCode"></param>
        /// <param name="startDate">start date range of schedule</param>
        /// <param name="endDate">end date range of schedule</param>
        /// <returns>a schedule list from lvivpuppet.com</returns>
        /// <response code="200">Returns a schedule list of appropriate language</response>
        /// <response code="400">If url which you are sending is not valid</response>
        /// <response code="404">If the information about schedule is null</response> 
        [HttpGet("{languageCode}/FilterByDate")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<ScheduleBase>> FilterByDate(
            string languageCode,
            DateTime? startDate, DateTime? endDate)
        {
            try
            {
                IEnumerable<ScheduleBase> schedule = service.FilterByDate(languageCode, startDate, endDate).ToList();

                if (schedule == null)
                    return NotFound();

                return StatusCode(200, schedule);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        #endregion
    }
}
