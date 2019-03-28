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

        /// <summary>
        /// Loads tags for the particular performance from lvivpuppet.com
        /// </summary>
        /// <param name="languageCode">Code of exist language(localisation of posters not supported yet, you can enter any value)</param>
        /// <returns>array of posters with selected language</returns>
        /// <response code="200">Returns list of  posters  with selected language</response>
        /// <response code="400">If url which you are sending is not valid</response>
        /// <response code="404">If the information about languageCode is null</response> 
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
