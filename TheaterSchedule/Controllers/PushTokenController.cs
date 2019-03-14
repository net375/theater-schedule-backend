using System;
using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.BLL.DTO;

namespace TheaterSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PushTokenController : ControllerBase
    {
        IPushTokenService pushTokenService;

        public PushTokenController(IPushTokenService pushTokenService)
        {
            this.pushTokenService = pushTokenService;
        }

        [HttpPost]
        public ActionResult<string> PostToken([FromBody] PushTokenDTO pushToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                pushTokenService.StorePushToken(pushToken.DeviceId, pushToken.Token);
                return StatusCode(201, pushToken.Token);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}