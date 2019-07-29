using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.Models;
using TheaterSchedule.BLL.DTOs;
using Microsoft.AspNetCore.Authorization;
using TheaterSchedule.MiddlewareComponents;

namespace TheaterSchedule.Controllers
{
    [ServiceFilter(typeof(CustomAuthorizationAttribute))]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Check is password valid and update user password
        /// </summary>
        /// <param name="input">Model with old and new password</param>
        /// <returns>Response status code</returns>
        /// <response code="204">When password successfully changed</response>
        /// <response code="404">If user is null</response> 
        /// <response code="400">If passed wrong old password</response> 
        [HttpPut]
        [Route("UpdatePassword")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdatePassword([FromBody]ChangePasswordModel input)
        {
            await _userService.UpdatePasswordAsync(new ChangePasswordDTO
            {
                Id = input.Id,
                OldPassword = input.OldPassword,
                NewPassword = input.NewPassword
            });

            return StatusCode(204);
        }

        /// <summary>
        /// Update user profile data
        /// </summary>
        /// <param name="input">Model with new profile data</param>
        /// <returns>Response status code and updated user model</returns>
        /// <response code="201">When profile successfully updated</response>
        /// <response code="404">If user is null</response> 
        /// <response code="400">If model is not valid</response> 
        [HttpPut]
        [Route("UpdateProfile")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ChangeProfileDTO>> UpdateProfile([FromBody]ChangeProfileModel input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _userService.UpdateProfileAsync(new ChangeProfileDTO
            {
                Id = input.Id,
                FirstName = input.FirstName,
                LastName = input.LastName,
                DateOfBirth = input.DateOfBirth,
                City = input.City,
                Country = input.Country,
                Email = input.Email,
                PhoneNumber = input.PhoneNumber,
            });

            return StatusCode(201, updated);
        }
    }
}