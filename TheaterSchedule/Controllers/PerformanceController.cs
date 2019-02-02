using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Entities;
using TheaterSchedule.DAL.Contexts;
using TheaterSchedule.DAL.Repositories;

namespace TheaterSchedule.Controllers
{   
    [Route("api/[controller]")]
    public class PerformanceController : Controller
    {
        private readonly ITheaterScheduleUnitOfWork uow;

        public PerformanceController(ITheaterScheduleUnitOfWork _uow)
        {
            uow = _uow;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get(int id) // this is just for test, ideally it should be async and send data and image separately
        {
            Performance performance = uow.Performances.Get(id);
            if (performance == null)
                return NotFound();
            return new ObjectResult(performance);
        }
     
        /*
        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
