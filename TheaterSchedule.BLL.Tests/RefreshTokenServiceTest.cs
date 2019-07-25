
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
using Entities.Models;
using TheaterSchedule.Infrastructure;
using TheaterSchedule.BLL.DTOs;

namespace TheaterSchedule.BLL.Tests
{
    [TestClass]
    public class RefreshTokenServiceTest
    {
        private RefreshTokenService refreshTokenService;
        private Mock<IRefreshTokenRepository> refreshTokenRepositoryMock;
        private Mock<ITokenService> tokenService;
        private Mock<IUserService> userService;
        private Mock<ITheaterScheduleUnitOfWork> theaterScheduleUnitOfWorkMock;
        private RefreshTokens refreshTokenInitialize; 
        private string refreshToken = "4wjRDjmSi9YfgFYAVM2QWjJxY8w1Ao6U7S6ZWX9VDCQ=";
        private int UserId = 91;
        private double daysToExpire = 3;

        [TestInitialize]
        public void SetUp()
        {
            theaterScheduleUnitOfWorkMock = new Mock<ITheaterScheduleUnitOfWork>();
            refreshTokenRepositoryMock = new Mock<IRefreshTokenRepository>();
            refreshTokenService = new RefreshTokenService(refreshTokenRepositoryMock.Object, tokenService.Object, userService.Object, theaterScheduleUnitOfWorkMock.Object);

            refreshTokenInitialize = new RefreshTokens()
            {
                Id = 1,
                UserId = 91,
                IsActive = true,
                RefreshToken = "4wjRDjmSi9YfgFYAVM2QWjJxY8w1Ao6U7S6ZWX9VDCQ=",
                DaysToExpire = Convert.ToDateTime("13.07.2019 11:45:12")
            };

            refreshTokenRepositoryMock.Setup(repo => repo.GetAsync(It.IsAny<System.Linq.Expressions.Expression<Func<RefreshTokens, bool>>>())).Returns(async () => { return refreshTokenInitialize; });
        }

        [TestMethod]
        public void GenerateRefreshTokenCheckReturnNewToken_Test()
        {
            var result = refreshTokenService.GenerateRefreshToken();

            Assert.AreEqual(typeof(string), result.GetType());
        }

        [TestMethod]
        public async Task GetAsyncCheckWhenRefreshTokenNull_Test()
        {
            refreshTokenRepositoryMock.Setup(repo => repo.GetAsync(It.IsAny<System.Linq.Expressions.Expression<Func<RefreshTokens, bool>>>())).Returns(async () => { return null; });

            HttpStatusCodeException ex = await Assert.ThrowsExceptionAsync<HttpStatusCodeException>(() => refreshTokenService.GetAsync(refreshToken));

            Assert.AreEqual("Such refresh token doesn't exist", ex.Message);
        }

        [TestMethod]
        public async Task GetAsyncCheckWhenRefreshTokenNotNull_Test()
        {
            refreshTokenRepositoryMock.Setup(repo => repo.GetAsync(It.IsAny<System.Linq.Expressions.Expression<Func<RefreshTokens, bool>>>())).Returns(async () => { return refreshTokenInitialize; });

            var result = await refreshTokenService.GetAsync(refreshToken);

            Assert.AreEqual(typeof(RefreshTokenDTO), result.GetType());
        }

        [TestMethod]
        public void UpdateRefreshTokenCheckWhenRefreshTokenNotNull_Test()
        {
            refreshTokenRepositoryMock.Setup(repo => repo.GetAsync(It.IsAny<System.Linq.Expressions.Expression<Func<RefreshTokens, bool>>>())).Returns(async () => { return refreshTokenInitialize; });

            refreshTokenRepositoryMock.Setup(repo => repo.UpdateAsync(refreshTokenInitialize)).Returns(async () => { return refreshTokenInitialize; });

            var result = refreshTokenService.UpdateRefreshTokenAsync(refreshTokenInitialize.Id, refreshToken, UserId, daysToExpire);

            Assert.IsTrue(result.IsCompleted);
        }

        [TestMethod]
        public async Task UpdateRefreshTokenCheckWhenRefreshTokenNull_Test()
        {
            refreshTokenRepositoryMock.Setup(repo => repo.GetAsync(It.IsAny<System.Linq.Expressions.Expression<Func<RefreshTokens, bool>>>())).Returns(async () => { return null; });

            HttpStatusCodeException ex = await Assert.ThrowsExceptionAsync<HttpStatusCodeException>(() => refreshTokenService.UpdateRefreshTokenAsync(refreshTokenInitialize.Id, refreshToken, UserId, daysToExpire));

            Assert.AreEqual("Such refresh token doesn't exist", ex.Message);
        }

        [TestMethod]
        public void AddRefreshTokenCheckWhenRefreshTokenNotExist_Test()
        {
            refreshTokenRepositoryMock.Setup(repo => repo.GetAsync(It.IsAny<System.Linq.Expressions.Expression<Func<RefreshTokens, bool>>>())).Returns(async () => { return null; });

            refreshTokenRepositoryMock.Setup(repo => repo.InsertAsync(refreshTokenInitialize)).Returns(async () => { return refreshTokenInitialize; });

            var result = refreshTokenService.AddRefreshTokenAsync(refreshToken, UserId, daysToExpire);

            Assert.IsTrue(result.IsCompleted);
        }

        [TestMethod]
        public void AddRefreshTokenCheckWhenRefreshTokenExist_Test()
        {
            var result = refreshTokenService.AddRefreshTokenAsync(refreshToken, UserId, daysToExpire);

            Assert.IsTrue(result.IsCompleted);
        }
    }
}