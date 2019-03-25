using Microsoft.AspNetCore.Mvc;
using System;
using TheaterSchedule.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using TheaterSchedule.BLL.DTO;
using System.Collections.Generic;
using System.Linq;

namespace TheaterSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostersController : ControllerBase
    {
        IPostersService postersService;
        public PostersController(IPostersService postersService)
        {
            this.postersService = postersService;
        }

        [HttpGet("{languageCode}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<PostersDTO>> Get(string languageCode)
        {
            try
            {
                IEnumerable<PostersDTO> posters = postersService.LoadPostersData(languageCode).ToList();

                if (posters == null)
                    return NotFound();

                return StatusCode(200, posters);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}
