using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.DAL.Contexts;
using TheaterSchedule.DAL.Entities;
using TheaterSchedule.DAL.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheaterSchedule.Controllers
{
    [Route("api/[controller]")]
    public class SettingsController : Controller
    {

        TheaterScheduleContext db;

        public SettingsController(TheaterScheduleContext context)
        {
            db = context;
        }
        //https://localhost:XXXXX/api/settings/XXX
        [HttpGet("{phoneId}")]
        public Settings Get(string phoneId)
        {
            using (TheaterSettingsUnitOfWork uow = new TheaterSettingsUnitOfWork(db))
            {
                return uow.Settings.GetSettingsByPhoneId(phoneId);
            }

        }


        //https://localhost:XXXXX/api/settings/XXX 
        /*{
          "languageId": "2"
           }*/
        [HttpPut("{phoneId}")]
        public Settings Put(string phoneId, [FromBody]Settings settings)
        {        
            using (TheaterSettingsUnitOfWork uow = new TheaterSettingsUnitOfWork(db))
            {
               uow.Settings.ChangeSettingsWithCurrentPhoneIdOrCreateNew(phoneId, settings);
               uow.Save();

                return uow.Settings.GetSettingsByPhoneId(phoneId);
            }
        }
    }
}
