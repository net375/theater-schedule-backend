using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheaterSchedule.Controllers
{
    [Route("api/[controller]")]
    public class SettingsController : Controller
    {

        ISettingsService settingsService;
        readonly ILogger<SettingsController> _log;

        public SettingsController(ISettingsService settingsService, ILogger<SettingsController> log)
        {
            this.settingsService = settingsService;
            this._log = log;
        }

        [HttpGet("{phoneId}")]
        public SettingsDTO Get(string phoneId)
        {
            _log.LogInformation("get phone id!");
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

