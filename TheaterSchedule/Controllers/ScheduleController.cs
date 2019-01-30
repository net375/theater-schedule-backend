using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.BLL;
using TheaterSchedule.DAL;
using TheaterSchedule.DAL.Contexts;
using TheaterSchedule.DAL.Repositories;

namespace TheaterSchedule.Controllers
{
    public class ScheduleController : Controller
    {
        IScheduleServices services;

        public ScheduleController(TheaterScheduleContext context)
        {
            this.services = new ScheduleServices(new TheaterScheduleUnitOfWork(context));
        }

        // GET: /<controller>/
        [HttpGet("{id}")]
        public IActionResult FilterPerformancesByDateRange()
        { 
            return View();
        }

        [HttpPost]
        public IEnumerable<Schedule> FilterPerformancesByDateRange(DateTime startRange, DateTime endRange)
        {
           return services.GetListPerformancesByDateRange(startRange, endRange);  
        }
    }
}
