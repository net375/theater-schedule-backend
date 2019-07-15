using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.DTOs;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.Controllers;

namespace TheaterSchedule.WebApiTest
{
    [TestClass]
    public class MessageControllerTest
    {
        private const int SomeId = 1;
        private static MessageDTO _someMessage = new MessageDTO
        {
            MessageId = 1,
            AccountId = 1,
            MessageText = "Nice",
            Subject = "SomePerformance",
        };

        private static MessageDTO _otherMessage = new MessageDTO
        {
            MessageId = 1,
            MessageText = "Nice",
            Subject = "SomePerformance",
        };


        [TestMethod]
        public void TestGetAll_200OK()
        {
            List<UserMessageDTO> messages = new List<UserMessageDTO>()
            {
                new UserMessageDTO()
                {
                    AccountId = 1,
                    Email = "@gmail.com",
                    FirstName = "Vasyl",
                    LastName = "Kurt",
                    MessageId = 1,
                    MessageText = "Perfect",
                    Subject = "Performance"
                },
                new UserMessageDTO()
                {
                    AccountId = 2,
                    Email = "@gmail.com",
                    FirstName = "Andriy",
                    LastName = "Big",
                    MessageId = 2,
                    MessageText = "Norm",
                    Subject = "Performance cool"
                }
            };

            var messageMock = new Mock<IMessageService>();
            messageMock.Setup(service=>service.GetAllMessages()).Returns(messages);
            var controller = new MessageController(messageMock.Object);

            var result = (controller.GetAllMessages()).Result as ObjectResult;
            var value = result.Value as List<UserMessageDTO>;

            Assert.IsNotNull(value);
            Assert.AreEqual(value.Count,2);
            Assert.AreEqual(value[0].LastName,messages[0].LastName);
            Assert.AreEqual(StatusCodes.Status200OK,result.StatusCode);

        }

        [TestMethod]
        public void TestGetAll_404NotFound()
        {

            var messageMock = new Mock<IMessageService>();
            messageMock.Setup(service => service.GetAllMessages()).Returns(()=>null);
            var controller = new MessageController(messageMock.Object);

            var result = (controller.GetAllMessages()).Result as IStatusCodeActionResult;

            Assert.AreEqual(StatusCodes.Status404NotFound, result.StatusCode);

        }


        [TestMethod]
        public void TestGetById_200OK()
        {
            var messageMock = new Mock<IMessageService>();
            messageMock.Setup(service => service.GetById(SomeId)).Returns(() => _someMessage);
            var controller = new MessageController(messageMock.Object);

            var result = (controller.GetMessage(SomeId)).Result as ObjectResult;
            var value = result.Value as MessageDTO;

            Assert.IsNotNull(value);
            Assert.AreEqual(value.AccountId,SomeId);
            Assert.AreEqual(result.StatusCode,StatusCodes.Status200OK);

        }

        [TestMethod]
        public void TestGetById_404NotFound()
        {
            var messageMock = new Mock<IMessageService>();
            messageMock.Setup(service => service.GetById(SomeId)).Returns(() => null);
            var controller = new MessageController(messageMock.Object);

            var result = (controller.GetMessage(SomeId)).Result as IStatusCodeActionResult;
            
            Assert.AreEqual(result.StatusCode, StatusCodes.Status404NotFound);
        }

        [TestMethod]
        public void TestSendMessage_201Created()
        {
            var messageMock = new Mock<IMessageService>();

            messageMock.Setup(m => m.SendMessage(_someMessage));
            var controller = new MessageController(messageMock.Object);

            var result = (controller.PostMessage(_someMessage)).Result as ObjectResult;
            var value = result.Value as MessageDTO;


            Assert.IsNotNull(value);
            Assert.AreEqual(value.MessageId,SomeId);
            Assert.AreEqual(result.StatusCode,StatusCodes.Status201Created);
        }

        [TestMethod]
        public void TestSendMessage_400BadRequest()
        {
            var messageMock = new Mock<IMessageService>();

            messageMock.Setup(m => m.SendMessage(_otherMessage)).Returns(()=> throw new System.ArgumentException("Some exception"));
            var controller = new MessageController(messageMock.Object);

            var result = (controller.PostMessage(_otherMessage)).Result as IStatusCodeActionResult;

            Assert.AreEqual(result.StatusCode, StatusCodes.Status400BadRequest);
        }
    }
}
