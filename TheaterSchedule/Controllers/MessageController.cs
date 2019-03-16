using System;
using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;

namespace TheaterSchedule.Controllers
{
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
        public ActionResult<MessageDTO> GetMessage(int id)
        {
            MessageDTO message = messageService.GetById(id);

            if (message == null)
            {
                return NotFound();
            }

            return message;
        }

        [HttpPost]
        public ActionResult<MessageDTO> PostMessage([FromBody] MessageDTO message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                messageService.SendMessage(message);
                return StatusCode(201, message);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}