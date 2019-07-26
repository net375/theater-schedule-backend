
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheaterSchedule.BLL.Services;
using TheaterSchedule.DAL.Interfaces;
using Moq;
using TheaterSchedule.BLL.Interfaces;
using System;
using System.Threading.Tasks;
using TheaterSchedule.Infrastructure;
using TheaterSchedule.Controllers;
using TheaterSchedule.Models;
using TheaterSchedule.BLL.DTOs;
using Entities.Models;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TheaterSchedule.BLL.Models;

namespace TheaterSchedule.BLL.Tests
{
    [TestClass]
    public class RefreshTokenServiceTest
    {
        private RefreshTokenModel _refreshTokenModel;
        private RefreshTokenDTO _refreshTokenDTO;
        private ApplicationUserDTO _applicationUserDTO;
        private RefreshTokenService _refreshTokenService;
        private Mock<IRefreshTokenRepository> _refreshTokenRepositoryMock;
        private Mock<ITokenService> _tokenService;
        private Mock<IUserService> _userService;
        private Mock<ITheaterScheduleUnitOfWork> theaterScheduleUnitOfWorkMock;
        private RefreshTokens refreshTokenInitialize;
        private string RefreshToken;
        private int UserId;
        private string AccessToken;
        private int DaysToExpire;
        private int Size;

        [TestInitialize]
        public void SetUp()
        {
            RefreshToken = "4wjRDjmSi9YfgFYAVM2QWjJxY8w1Ao6U7S6ZWX9VDCQ=";
            DaysToExpire = 3;
            AccessToken = "4wjRDjmSi9YfgFYAVM2QWjJxY8w1Ao6U7S6ZWX9VDCQ";
            Size = 32;
            UserId = 91;
            
            _userService = new Mock<IUserService>();
            _tokenService = new Mock<ITokenService>();
            theaterScheduleUnitOfWorkMock = new Mock<ITheaterScheduleUnitOfWork>();
            _refreshTokenRepositoryMock = new Mock<IRefreshTokenRepository>();

            _refreshTokenService = new RefreshTokenService(_refreshTokenRepositoryMock.Object, _tokenService.Object, _userService.Object, theaterScheduleUnitOfWorkMock.Object);
 
            _applicationUserDTO = new ApplicationUserDTO()
            {
                Id = 91,
                FirstName = "Volodya",
                LastName = "Khydzik",
                City = "Lviv",
                Country = "Lviv",
                Email = "parta1425326@i.ua",
                PhoneNumber = "0672530997",
                DateOfBirth = "20.07.2000"
            };

            _refreshTokenDTO = new RefreshTokenDTO()
            {
                Id = 1,
                IsActive = true,
                UserId = 91,
                RefreshToken = "4wjRDjmSi9YfgFYAVM2QWjJxY8w1Ao6U7S6ZWX9VDCQ =",
                DaysToExpire = DateTime.Now.AddDays(3)
            };

            _refreshTokenModel = new RefreshTokenModel()
            {
                RefreshToken = "4wjRDjmSi9YfgFYAVM2QWjJxY8w1Ao6U7S6ZWX9VDCQ="
            };

            _tokenService.Setup(service => service.GenerateAccessToken(_applicationUserDTO, RefreshToken)).Returns(() => { return AccessToken; });
        }

        [TestMethod]
        public void GenerateRefreshTokenCheckReturnNewToken_Test()
        {
            var result = _refreshTokenService.GenerateRefreshToken();

            Assert.AreEqual(typeof(string), result.GetType());
        }

        [TestMethod]
        public async Task GetAsyncCheckWhenRefreshTokenNull_Test()
        {
            _refreshTokenRepositoryMock.Setup(repo => repo.GetAsync(It.IsAny<System.Linq.Expressions.Expression<Func<RefreshTokens, bool>>>())).Returns(async () => { return null; });

            HttpStatusCodeException ex = await Assert.ThrowsExceptionAsync<HttpStatusCodeException>(() => _refreshTokenService.GetAsync(RefreshToken));

            Assert.AreEqual("Such refresh token doesn't exist", ex.Message);
        }

        [TestMethod]
        public async Task GetAsyncCheckWhenRefreshTokenNotNull_Test()
        {
            refreshTokenInitialize = new RefreshTokens()
            {
                Id = 1,
                UserId = 91,
                IsActive = true,
                RefreshToken = "4wjRDjmSi9YfgFYAVM2QWjJxY8w1Ao6U7S6ZWX9VDCQ=",
                DaysToExpire = DateTime.Now.AddDays(1)
            };

            _refreshTokenRepositoryMock.Setup(repo => repo.GetAsync(It.IsAny<System.Linq.Expressions.Expression<Func<RefreshTokens, bool>>>())).Returns(async () => { return refreshTokenInitialize; });

            var result = await _refreshTokenService.GetAsync(RefreshToken);

            Assert.AreEqual(typeof(RefreshTokenDTO), result.GetType());
        }


        [TestMethod]
        public void AddRefreshTokenCheckWhenRefreshTokenNotExist_Test()
        {
            _refreshTokenRepositoryMock.Setup(repo => repo.GetAsync(It.IsAny<System.Linq.Expressions.Expression<Func<RefreshTokens, bool>>>())).Returns(async () => { return null; });

            _refreshTokenRepositoryMock.Setup(repo => repo.InsertAsync(refreshTokenInitialize)).Returns(async () => { return refreshTokenInitialize; });

            var result = _refreshTokenService.AddRefreshTokenAsync(RefreshToken, UserId, DaysToExpire);

            Assert.IsTrue(result.IsCompleted);
        }

        [TestMethod]
        public void AddRefreshTokenCheckWhenRefreshTokenExist_Test()
        {
            var result = _refreshTokenService.AddRefreshTokenAsync(RefreshToken, UserId, DaysToExpire);

            Assert.IsTrue(result.IsCompleted);
        }

        [TestMethod]
        public void UpdateRefreshTokenCheckWhenRefreshTokenNotNull_Test()
        {
            refreshTokenInitialize = new RefreshTokens()
            {
                Id = 1,
                UserId = 91,
                IsActive = true,
                RefreshToken = "4wjRDjmSi9YfgFYAVM2QWjJxY8w1Ao6U7S6ZWX9VDCQ=",
                DaysToExpire = DateTime.Now.AddDays(1)
            };

            _refreshTokenRepositoryMock.Setup(repo => repo.GetAsync(It.IsAny<System.Linq.Expressions.Expression<Func<RefreshTokens, bool>>>())).Returns(async () => { return refreshTokenInitialize; });

            _refreshTokenRepositoryMock.Setup(repo => repo.UpdateAsync(refreshTokenInitialize)).Returns(async () => { return refreshTokenInitialize; });

            var result = _refreshTokenService.UpdateRefreshTokenAsync(refreshTokenInitialize.Id, RefreshToken, UserId, DaysToExpire);

            Assert.IsTrue(result.IsCompleted);
        }

        [TestMethod]
        public async Task UpdateRefreshTokenCheckWhenRefreshTokenNull_Test()
        {
            refreshTokenInitialize = new RefreshTokens()
            {
                Id = 1               
            };

            _refreshTokenRepositoryMock.Setup(repo => repo.GetAsync(It.IsAny<System.Linq.Expressions.Expression<Func<RefreshTokens, bool>>>())).Returns(async () => { return null; });

            HttpStatusCodeException ex = await Assert.ThrowsExceptionAsync<HttpStatusCodeException>(() => _refreshTokenService.UpdateRefreshTokenAsync(refreshTokenInitialize.Id, RefreshToken, UserId, DaysToExpire));

            Assert.AreEqual("Such refresh token doesn't exist", ex.Message);
        }

        [TestMethod]
        public async Task CheckRefreshTokenNull_Test()
        {
            _refreshTokenRepositoryMock.Setup(repo => repo.GetAsync(It.IsAny<System.Linq.Expressions.Expression<Func<RefreshTokens, bool>>>())).Returns(async () => { return null; });
            var ex = await Assert.ThrowsExceptionAsync<HttpStatusCodeException>(() => _refreshTokenService.CheckRefreshTokenAsync(RefreshToken));

            Assert.AreEqual("Such refreshToken doesn't exist", ex.Message);
            Assert.AreEqual(HttpStatusCode.NotFound, ex.StatusCode);
        }

        [TestMethod]
        public async Task CheckRefreshTokenInactive_Test()
        {
            refreshTokenInitialize = new RefreshTokens()
            {
                Id = 1,
                IsActive = false,
            };

            _refreshTokenRepositoryMock.Setup(repo => repo.GetAsync(It.IsAny<System.Linq.Expressions.Expression<Func<RefreshTokens, bool>>>())).Returns(async () => { return refreshTokenInitialize; });

            var ex = await Assert.ThrowsExceptionAsync<HttpStatusCodeException>(() => _refreshTokenService.CheckRefreshTokenAsync(RefreshToken));

            Assert.AreEqual("Such refresh token is inactive", ex.Message);
            Assert.AreEqual(HttpStatusCode.Unauthorized, ex.StatusCode);
        }

        [TestMethod]
        public async Task CheckRefreshTokenDaysToExpireInactive_Test()
        {
            refreshTokenInitialize = new RefreshTokens()
            {
                Id = 1,
                IsActive = true,
                DaysToExpire = Convert.ToDateTime("13.07.2019 11:45:12")
            };

            _refreshTokenRepositoryMock.Setup(repo => repo.GetAsync(It.IsAny<System.Linq.Expressions.Expression<Func<RefreshTokens, bool>>>())).Returns(async () => { return refreshTokenInitialize; });

            var ex = await Assert.ThrowsExceptionAsync<HttpStatusCodeException>(() => _refreshTokenService.CheckRefreshTokenAsync(_refreshTokenModel.RefreshToken));

            Assert.AreEqual("Days to expire of refresh token is inactive", ex.Message);
            Assert.AreEqual(HttpStatusCode.Unauthorized, ex.StatusCode);
        }

        [TestMethod]
        public async Task CheckRefreshTokenCheckUserIsNotExist_Test()
        {
            refreshTokenInitialize = new RefreshTokens()
            {
                Id = 1,
                UserId = 91,
                IsActive = true,
                RefreshToken = "4wjRDjmSi9YfgFYAVM2QWjJxY8w1Ao6U7S6ZWX9VDCQ=",
                DaysToExpire = DateTime.Now.AddDays(1)
            };

            _userService.Setup(service => service.GetByIdAsync(UserId)).Returns(async () => { return null; });
            _refreshTokenRepositoryMock.Setup(repo => repo.GetAsync(It.IsAny<System.Linq.Expressions.Expression<Func<RefreshTokens, bool>>>())).Returns(async () => { return refreshTokenInitialize; });

            var ex = await Assert.ThrowsExceptionAsync<HttpStatusCodeException>(() => _refreshTokenService.CheckRefreshTokenAsync(_refreshTokenModel.RefreshToken));

            Assert.AreEqual("Such user doesn't exist", ex.Message);
            Assert.AreEqual(HttpStatusCode.NotFound, ex.StatusCode);
        }

        [TestMethod]
        public async Task CheckRefreshTokenCheckReturnOK_Test()
        {
            refreshTokenInitialize = new RefreshTokens()
            {
                Id = 1,
                UserId = 91,
                IsActive = true,
                RefreshToken = "4wjRDjmSi9YfgFYAVM2QWjJxY8w1Ao6U7S6ZWX9VDCQ=",
                DaysToExpire = DateTime.Now.AddDays(1)
            };

            _refreshTokenRepositoryMock.Setup(repo => repo.GetAsync(It.IsAny<System.Linq.Expressions.Expression<Func<RefreshTokens, bool>>>())).Returns(async () => { return refreshTokenInitialize; });

            _userService.Setup(service => service.GetByIdAsync(UserId)).Returns(async () => { return _applicationUserDTO; });

            var actionResult = await _refreshTokenService.CheckRefreshTokenAsync(_refreshTokenModel.RefreshToken);

            Assert.AreEqual(typeof(TokensResponse), actionResult.GetType());
            Assert.IsNotNull(actionResult);
        }
    }
}