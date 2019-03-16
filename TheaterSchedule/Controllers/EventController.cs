using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;

namespace TheaterSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : Controller
    {
        IEventService service;

        public EventController(IEventService service)
        {
            this.service = service;
        }

        [HttpGet("{languageCode}/LoadAvailable")]
        public IEnumerable<EventDTO> LoadAvailable(string languageCode)
        {
            return service.LoadAvailable(languageCode).ToList();
        }
    }
}
