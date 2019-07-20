using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.BLL.DTOs;

namespace TheaterSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsPostController : ControllerBase
    {
        private IAdminsPostService adminsPostService;
        private IPushNotificationsService pushNotificationsService;
        public AdminsPostController(IAdminsPostService adminsPostService,IPushNotificationsService pushNotificationsService)
        {
            this.adminsPostService = adminsPostService;
            this.pushNotificationsService = pushNotificationsService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<AdminsPostDTO>> GetAllPublicPosts()
        {
            return Ok(adminsPostService.GetAllPublicPosts());
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<AdminsPostDTO>> GetAllPersonalPosts(int id)
        {
            return Ok(adminsPostService.GetAllPersonalPosts(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<AdminsPostDTO> AddNewAdminsPost(AdminsPostDTO post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            adminsPostService.AddNewPost(post);
            pushNotificationsService.SendPostPushNotification(post);
            return StatusCode(StatusCodes.Status201Created, post);
        }
    }
}
