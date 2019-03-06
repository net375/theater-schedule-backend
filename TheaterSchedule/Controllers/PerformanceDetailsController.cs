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

        public PerformanceDetailsController(IPerformanceDetailsService performanceDetailsService)
        {
            this.performanceDetailsService = performanceDetailsService;
        }

        [HttpGet("{phoneId}/{languageCode}/GetInfo")]
        public PerformanceDetailsDTOBase GetInfo(string phoneId, string languageCode, int id)
        {
            return performanceDetailsService.LoadPerformanceDetails(phoneId, languageCode, id);
        }
    }
}
