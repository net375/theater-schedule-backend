using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.BLL.DTOs;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.BLL.Services;
using AutoMapper;
using Entities.Models;

namespace TheaterSchedule.BLL.Tests
{
    [TestClass]
    public class AdminsPostServiceTest
    {
        Mock<IAdminsPostRepository> adminsPostRepository;
        Mock<ITheaterScheduleUnitOfWork> theaterScheduleUnitOfWork;
        IAdminsPostService adminsPostService;
        static IMapper mapper;

        static List<AdminsPost> adminsPostsPersonal;
        static List<AdminsPost> adminsPostsPublic;
        static int userId = 1;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdminsPost, AdminsPostDTO>()
                   .ReverseMap();
            });

            mapper = config.CreateMapper();

            adminsPostsPersonal = new List<AdminsPost>()
            {
                new AdminsPost
                {
                    AdminsPostId = 1,
                    Subject = "Subject 1",
                    PostText = "Post Text 1",
                    PostDate = new DateTime(),
                    IsPersonal = true,
                    ToUserId = userId,
                    ToUser = null
                },
                new AdminsPost
                {
                    AdminsPostId = 2,
                    Subject = "Subject 2",
                    PostText = "Post Text 2",
                    PostDate = new DateTime(),
                    IsPersonal = true,
                    ToUserId = userId,
                    ToUser = null
                }
            };
            adminsPostsPublic = new List<AdminsPost>()
            {
                new AdminsPost
                {
                    AdminsPostId = 0,
                    Subject = "Subject 0",
                    PostText = "Post Text 0",
                    PostDate = new DateTime(),
                    IsPersonal = false,
                    ToUserId = null,
                    ToUser = null
                },
                new AdminsPost
                {
                    AdminsPostId = 3,
                    Subject = "Subject 3",
                    PostText = "Post Text 3",
                    PostDate = new DateTime(),
                    IsPersonal = false,
                    ToUserId = null,
                    ToUser = null
                }
            };
        }

        [TestInitialize]
        public void Setup()
        {
            adminsPostRepository = new Mock<IAdminsPostRepository>();
            theaterScheduleUnitOfWork = new Mock<ITheaterScheduleUnitOfWork>();
        }

        [TestMethod]
        public void GetAllPublicPostsTest()
        {
            adminsPostRepository
                .Setup(post => post.GetAllPublic())
                .Returns(adminsPostsPublic);
            adminsPostService = new AdminsPostService(theaterScheduleUnitOfWork.Object, adminsPostRepository.Object);

            List<AdminsPost> posts = mapper.Map<List<AdminsPostDTO>, List<AdminsPost>>(adminsPostService.GetAllPublicPosts());

            CollectionAssert.AllItemsAreInstancesOfType(posts, typeof(AdminsPost));
            CollectionAssert.AllItemsAreNotNull(posts);
        }

        [TestMethod]
        public void GetAllPersonalPostsTest()
        {
            adminsPostRepository
                .Setup(post => post.GetAllPersonalById(userId))
                .Returns(adminsPostsPersonal);
            adminsPostService = new AdminsPostService(theaterScheduleUnitOfWork.Object, adminsPostRepository.Object);

            List<AdminsPost> posts = mapper.Map<List<AdminsPostDTO>, List<AdminsPost>>(adminsPostService.GetAllPublicPosts());

            CollectionAssert.AllItemsAreInstancesOfType(posts, typeof(AdminsPost));
            CollectionAssert.AllItemsAreNotNull(posts);
        }
    }
}
