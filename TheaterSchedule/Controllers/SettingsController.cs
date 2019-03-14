using Microsoft.AspNetCore.Mvc;
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
        public SettingsDTO Get(string phoneId)
        {          
            return settingsService.LoadSettings(phoneId);
        }

        [HttpPut("{phoneId}")]
        public ActionResult Put(string phoneId, [FromBody]SettingsDTO settings)
        {
            settingsService.StoreSettings(phoneId, settings);
            return Ok();
        }
    }
}

