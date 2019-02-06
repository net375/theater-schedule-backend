using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.BLL.Interfaces;

namespace TheaterSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostersController : ControllerBase
    {
        IPostersService postersService;
        public PostersController(IPostersService postersService)
        {
            this.postersService = postersService;
        }


        // GET: api/Posters
        [HttpGet("{settingsId}")]
        public JsonResult Get(int settingsId)
        {
            return new JsonResult(postersService.LoadPostersData(settingsId));
            //return postersService.LoadPostersData(settingsId);
        }

        // POST: api/Posters
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Posters/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
