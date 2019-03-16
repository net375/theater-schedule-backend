using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;

namespace TheaterSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcursionController : Controller
    {
        IExcursionService service;

        public ExcursionController(IExcursionService service)
        {
            this.service = service;
        }

        [HttpGet("{languageCode}/LoadAvailable")]
        public IEnumerable<ExcursionDTO> LoadAvailable(string languageCode)
        {
            return service.LoadAvailable(languageCode).ToList();
        }
    }
}
