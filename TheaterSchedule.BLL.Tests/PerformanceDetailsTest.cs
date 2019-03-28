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
using System.Threading.Tasks;

namespace TheaterSchedule.BLL.UnitTests
{
    [TestClass]
    public class PerformanceDetailsTest
    {
        Mock<IMemoryCache> memoryMock;
        Mock<ITagRepository> tagRepositoryMock;
        Mock<IPerformanceDetailsRepository> performanceDetailsRepositoryMock;
        Mock<IIsCheckedPerformanceRepository> isCheckedPerformanceRepositoryMock;
        Mock<ICreativeTeamRepository> creativeTeamRepositoryMock;
        Mock<ITheaterScheduleUnitOfWork> unitOfWorkMock;
        IPerformanceDetailsService performanceDetailsService;

        string languageCode = "uk";
        private string phoneId = "phoneId";
        private int performanceId = 411;

        private PerformanceDetailsWpDTO performance;
        [TestInitialize]
        public void SetUp()
        {
            var creativeTeam = new List<TeamMember>
            {
                new TeamMember
                {
                    FirstName = "Vasyl",
                    LastName = "Diakiv",
                    Role = "Producer",
                    RoleKey = "PRODUCER"
                },
                new TeamMember
                {
                    FirstName = "Vlad",
                    LastName = "Mamai",
                    Role = "Painter",
                    RoleKey = "PAINTER"
                },
                new TeamMember
                {
                    FirstName = "Oleh",
                    LastName = "Sihunov",
                    Role = "Composer",
                    RoleKey = "COMPOSER"
                }
            };
            var tags = new List<string> { "art", "comics" };
            var performanceDetails = new PerformanceDetailsDataModelWp()
            {
                MainImage = "jpg",
                GalleryImage = new List<string>()
                {
                    "jpg",
                    "jpg"
                },
                Duration = 50,
                MaxPrice = 80,
                MinPrice = 35,
                MinimumAge = 12,
                Description = "за однойменним твором Б. Стельмаха\n\nПроп",
                Title = "Тарас"
            };
            var isChecked = false;

            performance = new PerformanceDetailsWpDTO()
            {
                Title = performanceDetails.Title,
                Duration = performanceDetails.Duration,
                MinimumAge = performanceDetails.MinimumAge,
                MinPrice = performanceDetails.MinPrice,
                MaxPrice = performanceDetails.MaxPrice,
                Description = performanceDetails.Description,
                MainImage = performanceDetails.MainImage,
                GalleryImage = performanceDetails.GalleryImage,
                HashTag = from tg in tags
                    select tg,
                TeamMember = from tm in creativeTeam
                    select new TeamMemberDTO()
                    {
                        FirstName = tm.FirstName,
                        LastName = tm.LastName,
                        Role = tm.Role,
                        RoleKey = tm.RoleKey,
                    },
            };

            unitOfWorkMock = new Mock<ITheaterScheduleUnitOfWork>();
            performanceDetailsRepositoryMock = new Mock<IPerformanceDetailsRepository>();
            tagRepositoryMock = new Mock<ITagRepository>();
            creativeTeamRepositoryMock = new Mock<ICreativeTeamRepository>();
            isCheckedPerformanceRepositoryMock = new Mock<IIsCheckedPerformanceRepository>();

           object response = performance;

            memoryMock = new Mock<IMemoryCache>();
            memoryMock
                .Setup( x => x.TryGetValue( It.IsAny<object>(), out response ) )
                .Returns( true );

           creativeTeamRepositoryMock.Setup( x => x.GetCreativeTeam(
                    It.IsAny<string>(), It.IsAny<int>() ) )
                .Returns( creativeTeam );
            isCheckedPerformanceRepositoryMock.Setup( x => x.IsChecked(
                    It.IsAny<string>(), It.IsAny<int>() ) )
                .Returns( true );
            tagRepositoryMock.Setup( x => x.GetTagsByPerformanceId(
                    It.IsAny<int>() ) )
                .Returns(Task.FromResult( tags as IEnumerable<string>));
            performanceDetailsRepositoryMock.Setup( x => x.GetInformationAboutPerformance(
                    It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>() ) )
                .Returns( performanceDetails );

            performanceDetailsService = new PerformanceDetailsServiceWp( 
                unitOfWorkMock.Object,
                performanceDetailsRepositoryMock.Object,
                tagRepositoryMock.Object,
                creativeTeamRepositoryMock.Object,
                isCheckedPerformanceRepositoryMock.Object,
                memoryMock.Object);
        }


        [TestMethod]
        public void ListScheduleByRange()
        {
            PerformanceDetailsBaseDTO performanceDetailsExpected =
                performanceDetailsService.LoadPerformanceDetails(phoneId, languageCode, performanceId);
            Assert.AreEqual( performanceDetailsExpected, performance, "Performance are not equels" );
        }
    }
}
