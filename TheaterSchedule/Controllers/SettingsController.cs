using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Contexts;
using TheaterSchedule.DAL.Entities;
using TheaterSchedule.DAL.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

