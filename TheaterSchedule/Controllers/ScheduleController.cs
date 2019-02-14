using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;

namespace TheaterSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : Controller
    {
        private IScheduleService service;

        public ScheduleController(IScheduleService scheduleService)
        {
            service = scheduleService;
        }

        [HttpGet("{phoneId}/{languageCode}/FilterByDate")]
        public IEnumerable<ScheduleDTO> FilterByDate(
            string phoneId, string languageCode, 
            DateTime? startDate, DateTime? endDate)
        {
            return service.FilterByDate(phoneId, languageCode, startDate, endDate).ToList();
        }
    }
}
