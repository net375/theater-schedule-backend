using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Moq;
using NUnit.Framework;
using TheaterSchedule.BLL;
using TheaterSchedule.DAL.Interfaces;

namespace TheaterSchedule.DAL.UnitTests
{
    [TestFixture]
    public class PerformancesByDateRange
    {
        Mock<ITheaterScheduleUnitOfWork> performanceRepo;
        ScheduleServices performanceService;

        [SetUp]
        public void SetUp()
        {
            List<Schedule> ScheduleList = new List<Schedule>()
            {
                new Schedule()
                    {ScheduleId = 1, Beginning = new DateTime(2019, 02, 25), PerfomanceId = 1, Title = "Cinderella"},
                new Schedule()
                    {ScheduleId = 2, Beginning = new DateTime(2019, 02, 26), PerfomanceId = 1, Title = "Cinderella"},
                new Schedule()
                    {ScheduleId = 3, Beginning = new DateTime(2019, 02, 28), PerfomanceId = 1, Title = "Cinderella"},
                new Schedule()
                    {ScheduleId = 4, Beginning = new DateTime(2019, 03, 03), PerfomanceId = 1, Title = "Cinderella"},
                new Schedule()
                    {ScheduleId = 5, Beginning = new DateTime(2019, 02, 21), PerfomanceId = 1, Title = "Cinderella"},
                new Schedule()
                    {ScheduleId = 6, Beginning = new DateTime(2019, 02, 22), PerfomanceId = 1, Title = "Cinderella"},
            };

            IEnumerable<Schedule> listSchedule = ScheduleList.AsEnumerable();

            performanceRepo = new Mock<ITheaterScheduleUnitOfWork>();

            performanceRepo
                .Setup(k => k.Schedule.GetWithInclude(It.IsAny<Expression<Func<Schedule, object>>[]>()))
                .Returns(ScheduleList.AsQueryable());

            performanceService = new ScheduleServices(performanceRepo.Object);
        }

        [Test]
        public void ListScheduleByRange()
        {
            DateTime startRange = new DateTime(2019, 02, 25);
            DateTime endRange = new DateTime(2019, 03, 02);

            IEnumerable<Schedule> listScheduleExpected = performanceService.GetListPerformancesByDateRange(startRange, endRange);
            Assert.AreEqual(listScheduleExpected.Count(), 3, "Items count is not correct");
        }
    }
}
