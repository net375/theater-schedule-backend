using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.BLL.DTOs;
using TheaterSchedule.BLL.Interfaces;
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<ApplicationUserDTO> CreateUser(ApplicationUserDTO userDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            try
            {
                _service.Create(userDTO, userDTO.Password);
                return StatusCode(201, userDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        #endregion
    }
}
