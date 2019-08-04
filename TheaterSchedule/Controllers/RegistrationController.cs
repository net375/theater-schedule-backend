using System;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.BLL.DTOs;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.Infrastructure;

namespace TheaterSchedule.Controllers
{
    #region snippet_RegistrationController

    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IUserService _service;
        #endregion

        public RegistrationController(IUserService service)
        {
            _service = service;
        }
 
        #region snippet_CreateUser
        /// <summary>
        /// Register user in application
        /// </summary>
        /// <param name="userDTO">Model of user to create</param>
        /// <returns>created token</returns>
        /// <response code="201">Returns a model, wchich was created</response>
        /// <response code="404">If the model is null</response> 
        [HttpPost]
        [Route("CreateUser")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<ApplicationUserDTO> CreateUser([FromBody]ApplicationUserDTO userDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _service.Create(userDTO, userDTO.Password);
            if(user == null)
                throw new HttpStatusCodeException(
                        HttpStatusCode.Conflict, "Unable to create user");

            return StatusCode(201, user);
        }
        #endregion
    }
}