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

        [HttpGet("{languageCode}/FilterByDate")]
        public IEnumerable<ScheduleDTOBase> FilterByDate(
            string languageCode,
            DateTime? startDate, DateTime? endDate)
        {
            return service.FilterByDate(languageCode, startDate, endDate).ToList();
        }
    }
}
