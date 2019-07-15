using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using TheaterSchedule.BLL.DTOs;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.Controllers;
using TheaterSchedule.Models;
using Xunit;

namespace TheaterSchedule.WEB.Tests
{
    [ExcludeFromCodeCoverage]
    public class UserControllerTest
    {
        private static ChangePasswordModel SomePasswordModel = new ChangePasswordModel
        {
            Id = 1,
            OldPassword = "111111",
            NewPassword = "222222"
        };

        private static ChangePasswordDTO SomePasswordDTO = new ChangePasswordDTO {
            Id = 1,
            OldPassword = "111111",
            NewPassword = "222222"
        };

        private static ChangeProfileModel SomeChangeProfileModel = new ChangeProfileModel
        {
            Id = 1,
            FirstName = "Firstname",
            LastName = "Lastname",
            DateOfBirth = "01/01/1990",
            City = "City",
            Country = "Country",
            Email = "email@gmail.com",
            PhoneNumber = "+380979797979",
        };

        private static ChangeProfileDTO SomeChangeProfileDTO = new ChangeProfileDTO
        {
            Id = 1,
            FirstName = "Firstname",
            LastName = "Lastname",
            DateOfBirth = "01/01/1990",
            City = "City",
            Country = "Country",
            Email = "email@gmail.com",
            PhoneNumber = "+380979797979",
        };

        [Fact]
        public async Task TestUpdatePassword_204NoContent()
        {
            // Arrange
            var mock = new Mock<IUserService>();
            mock.Setup(serv => serv.UpdatePasswordAsync(SomePasswordDTO)).Returns(Task.CompletedTask);
            var controller = new UserController(mock.Object);

            // Act
            var result = (await controller.UpdatePassword(SomePasswordModel)) as IStatusCodeActionResult;

            // Assert
            Assert.Equal(StatusCodes.Status204NoContent, result.StatusCode);
        }

        [Fact]
        public async Task TestUpdateProfile_201Created()
        {
            // Arrange
            var mock = new Mock<IUserService>();
            mock.Setup(serv => serv.UpdateProfileAsync(SomeChangeProfileDTO)).Returns(async () => { return SomeChangeProfileDTO; });
            var controller = new UserController(mock.Object);

            // Act
            var result = (await controller.UpdateProfile(SomeChangeProfileModel)).Result as ObjectResult;
            var value = result.Value as ChangeProfileDTO;

            // Assert
            Assert.Equal(StatusCodes.Status201Created, result.StatusCode);
        }
    }
}
