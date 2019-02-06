using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;



namespace TheaterSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceController : Controller
    {
        IPerformanceService performanceService;

        public PerformanceController( IPerformanceService performanceService )
        {
            this.performanceService = performanceService;
        }

        [HttpGet("{languageCode}/GetInfo")]
        public PerformanceDTO GetInfo( string languageCode, int id )
        {
            return performanceService.LoadPerformance(languageCode, id);
        }
    }
}
