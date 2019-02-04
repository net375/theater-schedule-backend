using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.DAL.Contexts;
using TheaterSchedule.DAL.Entities;
using TheaterSchedule.DAL.Repositories;

namespace TheaterSchedule.Controllers
{
    [Route("api/Schedule")]
    [ApiController]
    public class ScheduleController : Controller
    {
        //  TheaterScheduleContext db;

        //public ScheduleController(TheaterScheduleContext context)
        //{
        //    db = context;
        //}

        //[HttpGet("FilterByDate")]
        //public IEnumerable<Schedule> FilterByDate(DateTime? startDate, DateTime? endDate)
        //{
        //    using (TheaterScheduleUnitOfWork uow = new TheaterScheduleUnitOfWork(db))
        //    {
        //       // return uow.Schedule.GetListPerformancesByDateRange(startDate, endDate).ToList();
        //    }
        //}
    }
}
