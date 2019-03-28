using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheaterSchedule.BLL.Services;
using TheaterSchedule.DAL.Interfaces;
using Moq;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Models;
using TheaterSchedule.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TheaterSchedule.BLL.Tests
{
    [TestClass]
    public class PerformanceScheduleTest
    {
        private PerformanceScheduleService performanceScheduleService;
        private Mock<ICacheProvider> cacheProvider;
        private Mock<IPerformanceScheduleRepository> performanceScheduleRepository;

        public int expectedPerformanceId;
        public PerformanceScheduleDataModel expectedPerformanceScheduleModel;

        [TestInitialize]
        public void SetUp()
        {
            expectedPerformanceId = 176;
            List<PerformanceScheduleDataModelBase> expectedScheduleList = new List<PerformanceScheduleDataModelBase>();
            List<TimeLink> timeLinks = new List<TimeLink>()
            {
                new TimeLink() {Time=new DateTime(2019, 04, 14, 12, 00, 00), Link= "https://ticketclub.com.ua/event/4984/?session=10798"},
                new TimeLink() {Time=new DateTime(2019, 04, 14, 14, 00, 00), Link= "https://ticketclub.com.ua/event/4984/?session=10799"},
                new TimeLink() {Time=new DateTime(2019, 04, 14, 16, 00, 00), Link= "https://ticketclub.com.ua/event/4984/?session=10800"},
            };
            expectedScheduleList.Add(new PerformanceScheduleDataModelBase() { Day = new DateTime(2019, 04, 14), TimeLinkList = timeLinks });
            expectedPerformanceScheduleModel = new PerformanceScheduleDataModel() { Title = "Таємниця Лісовичка", Age = 3, PerformanceId = expectedPerformanceId, Duration = 45, ScheduleList = expectedScheduleList };
            performanceScheduleRepository = new Mock<IPerformanceScheduleRepository>();
            performanceScheduleRepository.Setup(a => a.GetPerfomanceScheduleInfo(It.Is<int>(x => x == expectedPerformanceId))).Returns(Task.FromResult(expectedPerformanceScheduleModel));

            cacheProvider = new Mock<ICacheProvider>();
            cacheProvider.Setup(z => z.GetAndSave(It.Is<Func<string>>(x => x() == $"Performance_{expectedPerformanceId}"), It.Is<Func<PerformanceScheduleDataModel>>(x => x().PerformanceId == expectedPerformanceScheduleModel.PerformanceId))).Returns(expectedPerformanceScheduleModel);

            performanceScheduleService = new PerformanceScheduleService(performanceScheduleRepository.Object, cacheProvider.Object);

        }

        [TestMethod]
        public void LoadScheduleDataTest()
        {
            PerformanceScheduleDTO actualPerformanceScheduleDTO = performanceScheduleService.LoadScheduleData(expectedPerformanceId);

            cacheProvider.Verify((z => z.GetAndSave(It.Is<Func<string>>(x => x() == $"Performance_{expectedPerformanceId}"), It.Is<Func<PerformanceScheduleDataModel>>(x => x().PerformanceId == expectedPerformanceScheduleModel.PerformanceId))), Times.AtLeastOnce);
            performanceScheduleRepository.Verify(a => a.GetPerfomanceScheduleInfo(It.Is<int>(x => x == expectedPerformanceId)), Times.AtLeastOnce);

            Assert.AreEqual(expectedPerformanceScheduleModel.Title, actualPerformanceScheduleDTO.Title);
            Assert.AreEqual(expectedPerformanceScheduleModel.Duration, actualPerformanceScheduleDTO.Duration);
            Assert.AreEqual(expectedPerformanceScheduleModel.Age, actualPerformanceScheduleDTO.Age);
            Assert.AreEqual(expectedPerformanceScheduleModel.ScheduleList, actualPerformanceScheduleDTO.ScheduleList);
        }
    }
}
