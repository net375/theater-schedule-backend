using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;

namespace TheaterSchedule.Controllers
{
    [Route("api/[controller]")]
    public class SettingsController : Controller
    {
        ISettingsService settingsService;
   
        public SettingsController(ISettingsService settingsService)
        {
            this.settingsService = settingsService;         
        }
     
        [HttpGet("{phoneId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SettingsDTO> Get(string phoneId)
        {
            try
            {
                SettingsDTO settings = settingsService.LoadSettings(phoneId);

                if (settings == null)
                    return NotFound();

                return StatusCode(200, settings);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("{phoneId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        public ActionResult Put(string phoneId, [FromBody]SettingsDTO settings)
        {
            try
            {
                settingsService.StoreSettings(phoneId, settings);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}

