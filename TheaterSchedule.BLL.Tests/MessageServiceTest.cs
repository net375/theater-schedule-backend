using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.DTOs;
using TheaterSchedule.BLL.Services;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
using TheaterSchedule.BLL.Interfaces;

namespace TheaterSchedule.BLL.Tests
{
    [TestClass]
    public class MessageServiceTest
    {
        Mock<IUserRepository> userMock;
        Mock<IMessageRepository> messageMock;
        Mock<ITheaterScheduleUnitOfWork> unitOfWorkMock;
        private IMessageService messageService;
        private int id = 3;
        private int _userId = 95;
        MessageDTO messageAddDto = new MessageDTO()
            { AccountId = 95, MessageId = 5, MessageText = "Hi", Subject = "Performance" };

        [TestInitialize]
        public void SetUp()
        {
            Message messageAdd = new Message()
                { AccountId = 95, MessageId = 5, MessageText = "Hi", Subject = "Performance" };

            ApplicationUserModel userModel = new ApplicationUserModel()
            {
                Id = 95,
                DateOfBirth = new DateTime(1999, 6, 19, 12, 0, 0),
                City = "Lviv",
                Country = "Ukraine",
                Email = "jegerq@gmail.com",
                FirstName = "Vasyl",
                LastName = "Kyrt",
                PasswordHash = "das",
                PhoneNumber = "+380",
            };

            List<Message> messages = new List<Message>()
            {
                new Message()
                    { MessageId = 1,MessageText = "free",AccountId = 95,ReplyText = "access",Subject = "Performance"},
                new Message()
                    { MessageId = 2,MessageText = "The best performance i have ever seen!",AccountId = 95,ReplyText = "access",Subject = "Mystery of the forest"},
                new Message()
                    { MessageId = 3,MessageText = "Super",AccountId = 96,ReplyText = "access",Subject = "The road to Bethlehem"},
                new Message()
                    { MessageId = 4,MessageText = "The best performance i have ever seen!",AccountId = 95,ReplyText = "access",Subject = "Cedar seedlings"}
            };

            List<Account> users = new List<Account>()
            {
                new Account()
                {
                    AccountId = 95,
                    Birthdate = new DateTime(1999, 6, 19, 12, 0, 0),
                    City = "Lviv",
                    Country = "Ukraine",
                    Email = "jegerq@gmail.com",
                    FirstName = "Vasyl",
                    LastName = "Kyrt",
                    PasswordHash = "das",
                    PnoneNumber = "+380",
                },
                new Account()
                {
                    AccountId = 96,
                    Birthdate = new DateTime(1999, 6, 19, 12, 0, 0),
                    City = "Lviv",
                    Country = "Ukraine",
                    Email = "jegerq@gmail.com",
                    FirstName = "Vasyl",
                    LastName = "Kyrt",
                    PasswordHash = "das",
                    PnoneNumber = "+380",
                }
            };

            var usersQueryable = users.AsQueryable();

            
            messageMock = new Mock<IMessageRepository>();
            unitOfWorkMock = new Mock<ITheaterScheduleUnitOfWork>();
            userMock= new Mock<IUserRepository>();

            object response = messages;

            
            unitOfWorkMock.Setup(m => m.Save());

            messageMock.Setup(m => m.GetUnrepliedMessages()).Returns(messages);

            messageMock.Setup(m=>m.GetMessageById(id)).Returns(messages[2]);

            messageMock.Setup(m=>m.Add(messageAdd));

            userMock.Setup(u => u.GetById(_userId)).Returns(userModel);

            userMock.Setup(u => u.GetAll()).Returns(usersQueryable);

            messageService = new MessageService(unitOfWorkMock.Object,messageMock.Object,userMock.Object);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<Message, MessageDTO>(It.IsAny<Message>())).Returns(new MessageDTO());
        }

        [TestMethod]
        public void ListMessage()
        {
            List<UserMessageDTO> listMessageExpected = messageService.GetAllMessages();
            Assert.AreEqual(listMessageExpected.Count,4,"List count is not correct");
        }

        [TestMethod]
        public void ByIdMessage()
        {
            MessageDTO messageExpected = messageService.GetById(id);
            Assert.AreEqual(messageExpected.Subject, "The road to Bethlehem","Subject is not correct");
            Assert.AreEqual(messageExpected.MessageText, "Super","MessageText is not correct");
        }

        [TestMethod]
        public void SendMessage()
        {
            var result = messageService.SendMessage(messageAddDto);

            Assert.IsTrue(result.IsCompleted);
        }


    }
}
