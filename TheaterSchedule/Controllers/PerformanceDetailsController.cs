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
    public class PerformanceDetailsController : Controller
    {
        IPerformanceDetailsService performanceDetailsService;

        public PerformanceDetailsController( IPerformanceDetailsService performanceDetailsService )
        {
            this.performanceDetailsService = performanceDetailsService;
        }

        [HttpGet("{languageCode}/GetInfo")]
        public PerformanceDetailsDTO GetInfo( string languageCode, int id )
        {
            return performanceDetailsService.LoadPerformanceDetails(languageCode, id);
        }
    }
}
