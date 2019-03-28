using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Services;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
using TheaterSchedule.BLL.Interfaces;

namespace TheaterSchedule.BLL.UnitTests
{
    [TestClass]
    public class ScheduleService
    {
        Mock<IMemoryCache> memoryMock;
        Mock<IScheduleRepository> scheduleMock;
        Mock<ITheaterScheduleUnitOfWork> unitOfWorkMock;
        private IScheduleService scheduleService;

        DateTime startDate = new DateTime(2019, 02, 25);
        DateTime endDate = new DateTime(2019, 03, 02);
        string languageCode = "uk";

        [TestInitialize]
        public void SetUp()
        {
            List<ScheduleDataModelWp> schedule = new List<ScheduleDataModelWp>()
            {
                new ScheduleDataModelWp()
                    {Beginning = new DateTime(2019, 02, 25), PerformanceId = 176, Title = "Таємниця лісовичка", MainImage = "https://lvivpuppet.com/wp-content/uploads/2019/01/lisovychok_resize.jpg", redirectToTicket = "https://ticketclub.com.ua/event/4984/?session=10610"},
                new ScheduleDataModelWp()
                    {Beginning = new DateTime(2019, 02, 26), PerformanceId = 65, Title = "Садок вишневий", MainImage = "https://lvivpuppet.com/wp-content/uploads/2018/10/sadok_resize.jpg", redirectToTicket = "https://ticketclub.com.ua/eventsession/10591/"},
                new ScheduleDataModelWp()
                    {Beginning = new DateTime(2019, 02, 28), PerformanceId = 149, Title = "Лисичка, Котик і Півник", MainImage = "https://lvivpuppet.com/wp-content/uploads/2018/10/kotyk_pivnyk_resize.jpg", redirectToTicket = "https://ticketclub.com.ua/event/4986/?session=10807"},
                new ScheduleDataModelWp()
                    {Beginning = new DateTime(2019, 03, 03), PerformanceId = 104, Title = "Тарас", MainImage = "https://lvivpuppet.com/wp-content/uploads/2018/06/Taras_resize.jpg", redirectToTicket = "https://ticketclub.com.ua/event/4892/?session=10620"},
                new ScheduleDataModelWp()
                    {Beginning = new DateTime(2019, 02, 21), PerformanceId = 48, Title = "А де ж п'яте", MainImage = "https://lvivpuppet.com/wp-content/uploads/2018/10/Where-is-5th_resize.jpg", redirectToTicket = "https://ticketclub.com.ua/event/4985/?session=10796"},
                new ScheduleDataModelWp()
                    {Beginning = new DateTime(2019, 02, 22), PerformanceId = 104, Title = "Тарас", MainImage = "https://lvivpuppet.com/wp-content/uploads/2018/06/Taras_resize.jpg", redirectToTicket = "https://ticketclub.com.ua/event/4892/?session=10620"},
            };

            scheduleMock = new Mock<IScheduleRepository>();
            unitOfWorkMock = new Mock<ITheaterScheduleUnitOfWork>();

            object response = schedule;

            memoryMock = new Mock<IMemoryCache>();
            memoryMock
                .Setup(x => x.TryGetValue(It.IsAny<object>(), out response))
                .Returns(true);

            scheduleMock
                .Setup(s => s.GetListPerformancesByDateRange(languageCode, startDate, endDate))
                .Returns(schedule);

            scheduleService = new ScheduleServiceWp(unitOfWorkMock.Object, scheduleMock.Object, memoryMock.Object);
        }


        [TestMethod]
        public void ListScheduleByRange()
        {
            IEnumerable<ScheduleBaseDTO> listScheduleExpected = scheduleService.FilterByDate(languageCode, startDate, endDate);
            Assert.AreEqual(listScheduleExpected.Count(), 3, "Schedule count is not correct");
        }
    }
}
