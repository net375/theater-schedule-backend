using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.Models;

namespace TheaterSchedule.Controllers
{
    #region snippet_ForgotPasswordController
    [Route("api/[controller]")]
    [ApiController]
    public class ForgotPasswordController : ControllerBase
    {
        private readonly IResetCodeService _service;
        #endregion

        public ForgotPasswordController(IResetCodeService service)
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
        public ActionResult<ForgotPasswordModel> GenerateResetCode([FromBody]ForgotPasswordModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _service.GenerateResetCodeAsync(model.Email);

            return StatusCode(201);
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
        [Route("ValidateCode")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ResetCodeModel> ValidateResetCode([FromBody]ResetCodeModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.ValidateCode(model.Code);

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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.ResetPassword(model.Password);
            return StatusCode(200);
        }
        #endregion
    }
}
