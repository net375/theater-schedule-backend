using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using Microsoft.AspNetCore.Http;

namespace TheaterSchedule.Controllers
{
    #region snippet_EventController

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : Controller
    {
        IEventService service;

        #endregion

        public EventController(IEventService service)
        {
            this.service = service;
        }

        #region snippet_LoadEvents

        /// <summary>
        /// Loads events from database
        /// </summary>
        /// <param name="languageCode"></param>
        /// <returns>a list of events</returns>
        /// <response code="200">Returns the available events of appropriate language</response>
        /// <response code="400">If the events list is null</response>
        /// <response code="404">If the information about events is null</response> 
        [HttpGet("{languageCode}/LoadEvents")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<Event>> LoadEvents(string languageCode)
        {
            try
            {
                IEnumerable<Event> events = service.LoadAvailable(languageCode).ToList();

                if (events == null)
                    return NotFound();

                return StatusCode(200, events);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        #endregion
    }
}
