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
    public class PromoActionController : Controller
    {
        IPromoActionService service;

        public PromoActionController(IPromoActionService service)
        {
            this.service = service;
        }

        [HttpGet("{languageCode}/LoadAvailable")]
        public IEnumerable<PromoActionDTO> LoadAvailable(string languageCode)
        {
            return service.LoadAvailable(languageCode).ToList();
        }
    }
}