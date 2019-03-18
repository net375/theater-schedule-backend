using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.BLL.DTO;

namespace TheaterSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceScheduleController : ControllerBase
    {
        private IPerformanceScheduleService performanceScheduleService;
        public PerformanceScheduleController(IPerformanceScheduleService performanceScheduleService)
        {
            this.performanceScheduleService = performanceScheduleService;
        }

        [HttpGet("{id}", Name = "Get")]
        public PerformanceScheduleDTO Get(int id)
        {
            return performanceScheduleService.LoadScheduleData(id);
        }
                
    }
}
