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
        [HttpGet("{languageCode}")]
        public async Task<JsonResult> Get(string languageCode)
        {
            return new JsonResult(await postersService.LoadPostersData(languageCode));
        }

    }
}
