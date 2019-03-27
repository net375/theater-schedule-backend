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

        /// <summary>
        /// Loads tags for the particular performance from lvivpuppet.com
        /// </summary>
        /// <param name="id">performance id</param>
        /// <returns>array of hashtags</returns>
        /// <response code="200">Returns list of hashtags for the particular performance</response>
        /// <response code="400">If url which you are sending is not valid</response>
        /// <response code="404">If the information about performance is null</response> 
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<TagDTO> Get(int id)
        {
            try
            {
                TagDTO tags = tagService.LoadTagsById(id);

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
