using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.BLL.DTOs;
using Microsoft.AspNetCore.Http;
using TheaterSchedule.Infrastructure;
using System.Net;

namespace TheaterSchedule.Controllers
{
    #region snippet_FormUrlController

    [Route("api/[controller]")]
    [ApiController]
    public class FormUrlController : Controller
    {
        private readonly IFormService _service;
        #endregion

        public FormUrlController(IFormService service)
        {
            _service = service;
        }


        #region snippet_AddUrl
        /// <summary>
        /// Save google form url in database
        /// </summary>
        /// <param name="urlDTO">Model of url to save in database</param>
        /// <returns>added url</returns>
        /// <response code="201">Returns a model, wchich was created</response>
        /// <response code="404">If the model is null</response> 
        [HttpPost]
        [Route("AddUrl")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<ApplicationUserDTO> AddUrl([FromBody]UrlDTO urlDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var link = _service.Add(urlDTO);
            if (link == null)
                throw new HttpStatusCodeException(
                        HttpStatusCode.NotFound, $"Unable to add link");

            return StatusCode(201, link);
        }
        #endregion
    }
}