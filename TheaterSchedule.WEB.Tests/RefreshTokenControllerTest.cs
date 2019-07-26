using System;
using System.Threading.Tasks;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.Infrastructure;
using TheaterSchedule.Controllers;
using TheaterSchedule.Models;
using TheaterSchedule.BLL.DTOs;
using Moq;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheatherSchedule.Web.Test
{
    [TestClass]
    public class RefreshTokenControllerTest
    {
        private RefreshTokenController _refreshTokenController;
        private Mock<IUserService> _userService;
        private Mock<IRefreshTokenService> _refreshTokenService;
        private Mock<ITokenService> _tokenService;
        private RefreshTokenModel _refreshTokenModel;
        private RefreshTokenDTO _refreshTokenDTO;
        private ApplicationUserDTO _applicationUserDTO;
        private int UserId;
        private string AccessToken;
        private int DaysToExpire;
        private int Size;

        [TestInitialize]
        public void SetUp()
        {
            DaysToExpire = 3;
            AccessToken = "4wjRDjmSi9YfgFYAVM2QWjJxY8w1Ao6U7S6ZWX9VDCQ";
            Size = 32;
            UserId = 91;
            _userService = new Mock<IUserService>();
            _refreshTokenService = new Mock<IRefreshTokenService>();
            _tokenService = new Mock<ITokenService>();
            _refreshTokenController = new RefreshTokenController(_tokenService.Object, _refreshTokenService.Object, _userService.Object);

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

            _refreshTokenService.Setup(service => service.UpdateRefreshTokenAsync(_refreshTokenDTO.Id, _refreshTokenDTO.RefreshToken, _refreshTokenDTO.UserId, DaysToExpire, true)).Returns(Task.CompletedTask);
            _tokenService.Setup(service => service.GenerateAccessToken(_applicationUserDTO, _refreshTokenModel.RefreshToken)).Returns(() => { return AccessToken; });
            _refreshTokenService.Setup(service => service.GenerateRefreshToken(Size)).Returns(() => { return _refreshTokenModel.RefreshToken; });
        }       

        [TestMethod]
        public async Task DeleteRefreshTokenCheckRefreshTokenNull_Test()
        {
            _refreshTokenService.Setup(service => service.GetAsync(_refreshTokenModel.RefreshToken)).Returns(async () => { return null; });

            var ex = await Assert.ThrowsExceptionAsync<HttpStatusCodeException>(() => _refreshTokenController.DeleteRefreshTokenAsync(_refreshTokenModel));

            Assert.AreEqual("Such refreshToken doesn't exist", ex.Message);
            Assert.AreEqual(HttpStatusCode.NotFound, ex.StatusCode);
        }

        [TestMethod]
        public async Task DeleteRefreshTokenCheckUserIsNotExist_Test()
        {
            _userService.Setup(service => service.GetByIdAsync(UserId)).Returns(async () => { return null; });
            _refreshTokenService.Setup(service => service.GetAsync(_refreshTokenModel.RefreshToken)).Returns(async () => { return _refreshTokenDTO; });

            var ex = await Assert.ThrowsExceptionAsync<HttpStatusCodeException>(() => _refreshTokenController.DeleteRefreshTokenAsync(_refreshTokenModel));

            Assert.AreEqual("Such user doesn't exist", ex.Message);
            Assert.AreEqual(HttpStatusCode.NotFound, ex.StatusCode);
        }

        [TestMethod]
        public async Task DeleteRefreshTokenCheckReturnOk_Test()
        {
            _refreshTokenService.Setup(service => service.GetAsync(_refreshTokenModel.RefreshToken)).Returns(async () => { return _refreshTokenDTO; });

            _userService.Setup(service => service.GetByIdAsync(UserId)).Returns(async () => { return _applicationUserDTO; });

            var actionResult = await _refreshTokenController.DeleteRefreshTokenAsync(_refreshTokenModel);
            var contentResult = actionResult.Result as IStatusCodeActionResult;

            Assert.AreEqual(StatusCodes.Status200OK, contentResult.StatusCode);
        }
    }
}
