using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TheaterSchedule.BLL.Services;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.BLL.DTO;
using Entities.Models;
using System.Linq;

namespace TheaterSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        IPushNotificationsService pushNotificationsService;
        
        public TestController(IPushNotificationsService pushNotificationsService)
        {
            this.pushNotificationsService = pushNotificationsService;
        }
        // GET api/test
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //Hangfire.BackgroundJob.Enqueue(() => pushNotificationsService.SendPushNotification());

            Hangfire.RecurringJob.AddOrUpdate(() => pushNotificationsService.SendPushNotification(),
                                                "0 9 * * *");

            return new string[] { "testValue1", "testValue2", "testValue2" };
        }

        // GET api/test/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "testValue";
        }

        // POST api/test
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/test/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/test/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
