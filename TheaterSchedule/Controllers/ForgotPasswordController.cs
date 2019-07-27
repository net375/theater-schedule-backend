using System;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.BLL.DTOs;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.Infrastructure;
using TheaterSchedule.Models;
using System.Threading.Tasks;

namespace TheaterSchedule.Controllers
{
    #region snippet_ForgotPasswordController

    [Route("api/[controller]")]
    [ApiController]
    public class ForgotPasswordController : ControllerBase
    {
        private readonly IUserService _service;
        #endregion

        public ForgotPasswordController(IUserService service)
        {
            _service = service;
        }

        #region snippet_GenerateVerificationCode
        ///<summary>
        ///Generate code for reset password
        ///</summary>
        ///<param name="model">Model of email to create reset code</param>
        ///<returns>nothing</returns>
        ///<response code="404">If the model is null</response>
        [HttpPost]
        [Route("GenerateResetCode")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<int> GenerateResetCode([FromBody]ForgotPasswordModel model)
        {
            //if (!ModelState.IsValid)
                //return BadRequest(ModelState);

            var userId = _service.GenerateResetCode(model.Email);

            return StatusCode(201, userId);       
        }
        #endregion

        #region snippet_ValidateCode
        /// <summary>
        /// Validate reset code
        /// </summary>
        /// <param name="model">Model of reset code to validate</param>
        /// <returns>Nothing</returns>
        /// <response code="200">If request if OK</response>
        /// <response code ="404">If code is null</response>

        [HttpPost]
        [Route("ValidateResetCode")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ResetCodeModel> ValidateResetCode([FromBody]ResetCodeModel model)
        {
            //if (!ModelState.IsValid)
            //{
                //return BadRequest(ModelState);
            //}

            _service.ValidateResetCodeAsync(new ValidationCodeDTO
            {
                Id = model.Id,
                ValidationCode = model.ValidationCode
            });

            return StatusCode(200);
        }
        #endregion

        #region snippet_ResetPassword
        /// <summary>
        /// Resets user password
        /// </summary>
        /// <param name="model">Model of new password</param>
        /// <returns>Nothing</returns>
        /// <response code="200">If request if OK</response>
        /// <response code ="404">If password is null</response>

        [HttpPut]
        [Route("ResetPassword")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ResetPasswordModel> ResetPassword([FromBody]ResetPasswordModel model)
        {
            //if (!ModelState.IsValid)
            //{
                //return BadRequest(ModelState);
            //}

            _service.ResetPasswordAsync(new ResetPasswordDTO
            {
                Id = model.Id,
                Password = model.Password
            });

            return StatusCode(200);
        }
        #endregion
    }
}
