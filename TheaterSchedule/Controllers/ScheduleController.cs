using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.BLL;
using TheaterSchedule.DAL;
using TheaterSchedule.DAL.Contexts;
using TheaterSchedule.DAL.Entities;
using TheaterSchedule.DAL.Repositories;

namespace TheaterSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : Controller
    {
        IScheduleServices services;

        public ScheduleController(TheaterScheduleContext context)
        {
            this.services = new ScheduleServices(new TheaterScheduleUnitOfWork(context));
        }

        [HttpGet("startDate={startDate}&endDate={endDate}")]
        public IEnumerable<Schedule> FilterPerformancesByDateRange(string startDate = null, string endDate = null)
        {
            startDate = startDate.Replace('-', '/');
            endDate = endDate.Replace('-', '/');    
            DateTime start = DateTime.ParseExact(startDate, "MM/dd/yyyy", null);
            DateTime end = DateTime.ParseExact(endDate, "MM/dd/yyyy", null);

            return services.GetListPerformancesByDateRange(start, end);  
        }
    }
}
