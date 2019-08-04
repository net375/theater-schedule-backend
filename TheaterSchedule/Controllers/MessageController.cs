using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.DTOs;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.MiddlewareComponents;

namespace TheaterSchedule.Controllers
{
    [ServiceFilter(typeof(CustomAuthorizationAttribute))]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        IMessageService messageService;

        public MessageController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MessageDTO> GetMessage(int id)
        {
            MessageDTO message = messageService.GetById(id);

            if (message == null)
            {
                return NotFound();
            }

            return Ok(message);
        }

        [ServiceFilter(typeof(CustomAuthorizationAttribute))]
        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<MessageDTO> PostMessage([FromBody] MessageDTO message)
        {
            messageService.SendMessage(message);
                return StatusCode(201, message);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public  ActionResult<List<MessageDTO>> GetAllMessages()
        {
            List<UserMessageDTO> messages =  messageService.GetAllMessages();

            if (messages == null)
            {
                return NotFound();
            }

            return Ok(messages);
        }
    }
}