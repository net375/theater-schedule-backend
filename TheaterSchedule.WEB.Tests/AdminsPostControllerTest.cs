using System.Diagnostics.CodeAnalysis;
using Xunit;
using Moq;
using TheaterSchedule.BLL.Interfaces;
using System.Collections.Generic;
using TheaterSchedule.BLL.DTOs;
using System;
using TheaterSchedule.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace TheaterSchedule.WEB.Tests
{
    [ExcludeFromCodeCoverage]
    public class AdminsPostControllerTest
    {
        private static IEnumerable<AdminsPostDTO> publicPosts;
        private static IEnumerable<AdminsPostDTO> privatePosts;
        private static AdminsPostDTO newPost;

        static AdminsPostControllerTest()
        {
            publicPosts = new List<AdminsPostDTO>
            {
                new AdminsPostDTO()
                {
                    AdminsPostId = 0,
                    Subject = "Subject",
                    PostText = "Post Text",
                    PostDate = DateTime.Now,
                    IsPersonal = false,
                    ToUserId = null
                },
                new AdminsPostDTO()
                {
                    AdminsPostId = 1,
                    Subject = "Subject",
                    PostText = "Post Text",
                    PostDate = DateTime.Now,
                    IsPersonal = false,
                    ToUserId = null
                }
            };

            privatePosts = new List<AdminsPostDTO>
            {
                new AdminsPostDTO()
                {
                    AdminsPostId = 2,
                    Subject = "Subject",
                    PostText = "Post Text",
                    PostDate = DateTime.Now,
                    IsPersonal = true,
                    ToUserId = 0
                },
                new AdminsPostDTO()
                {
                    AdminsPostId = 3,
                    Subject = "Subject",
                    PostText = "Post Text",
                    PostDate = DateTime.Now,
                    IsPersonal = true,
                    ToUserId = 1
                },
                new AdminsPostDTO()
                {
                    AdminsPostId = 4,
                    Subject = "Subject",
                    PostText = "Post Text",
                    PostDate = DateTime.Now,
                    IsPersonal = true,
                    ToUserId = 0
                },
                new AdminsPostDTO()
                {
                    AdminsPostId = 5,
                    Subject = "Subject",
                    PostText = "Post Text",
                    PostDate = DateTime.Now,
                    IsPersonal = true,
                    ToUserId = 1
                }
            };

            newPost = new AdminsPostDTO()
            {
                AdminsPostId = 0,
                Subject = "Subject",
                PostText = "Post Text",
                PostDate = DateTime.Now,
                IsPersonal = false,
                ToUserId = null
            };
        }

        [Fact]
        public void GetAllPublicPosts_Test()
        {
            // Arrange
            var mock = new Mock<IAdminsPostService>();
            var notificationMock = new Mock<IPushNotificationsService>();
            mock.Setup(serv => serv.GetAllPublicPosts()).Returns(publicPosts);
            var controller = new AdminsPostController(mock.Object, notificationMock.Object);

            // Act
            var result = controller.GetAllPublicPosts().Result as ObjectResult;

            // Assert
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.Equal(publicPosts, result.Value);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void GetAllPrivatePosts_Test(int id)
        {
            // Arrange
            var mock = new Mock<IAdminsPostService>();
            var notificationMock = new Mock<IPushNotificationsService>();
            var filteredPosts = privatePosts.Where(post => post.ToUserId == id);
            mock.Setup(serv => serv.GetAllPersonalPosts(id)).Returns(filteredPosts);
            var controller = new AdminsPostController(mock.Object, notificationMock.Object);

            // Act
            var result = controller.GetAllPersonalPosts(id).Result as ObjectResult;

            // Assert
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.Equal(filteredPosts, result.Value);
        }

        [Fact]
        public void AddNewPost_Test()
        {
            // Arrange
            var mock = new Mock<IAdminsPostService>();
            var notificationMock = new Mock<IPushNotificationsService>();
            mock.Setup(serv => serv.AddNewPost(newPost));
            var controller = new AdminsPostController(mock.Object, notificationMock.Object);

            // Act
            var result = controller.AddNewAdminsPost(newPost).Result as ObjectResult;

            // Assert
            Assert.Equal(StatusCodes.Status201Created, result.StatusCode);
            Assert.Equal(newPost, result.Value);
        }
    }
}
