using Microsoft.AspNetCore.Mvc;
using System;
using TheaterSchedule.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using TheaterSchedule.BLL.DTO;
using System.Collections.Generic;

namespace TheaterSchedule.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private ITagService tagService;
        public TagController(ITagService tagService)
        {
            this.tagService = tagService;
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Tag> Get(int id)
        {
            try
            {
                Tag tags = tagService.LoadTagsById(id);

                if (tags == null)
                    return NotFound();

                return StatusCode(200, tags);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
