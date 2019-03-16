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

        [HttpGet("{languageCode}")]
        public JsonResult Get(string languageCode)
        {
            return new JsonResult(postersService.LoadPostersData(languageCode));
        }

    }
}
