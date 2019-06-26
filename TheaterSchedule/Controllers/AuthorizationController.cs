using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using TheaterSchedule.BLL.DTOs;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.Formatters;
using TheaterSchedule.Infrastructure;

namespace TheaterSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private IAuthorizationService _authorizationService;
        private ITokenFormation _tokenFormation;

        public AuthorizationController(IAuthorizationService authorizationService, ITokenFormation tokenFormation)
        {           
            _authorizationService = authorizationService;
            _tokenFormation = tokenFormation;
        }


        /// <summary>
        ///     Authorization user in database and retun information about user in response (lvivpuppet.com)
        /// </summary>
        /// <param name="email"></param> 
        /// <param name="password"></param>
        /// <returns>Information about user in response and token</returns>
        /// <response code="200">Returns the information about user  and token</response>
        /// <response code="400">If url which you are sending is not valid</response>
        /// <response code="404">If the information about user is null</response> 
        [HttpPost]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApplicationUserDTO>> AuthorizationAsync(string email, string password)
        {
            //if (!ModelState.IsValid)
            //     return BadRequest(ModelState);

            try
            {
                var userResult = await _authorizationService.GetUserAsync(email, password);

                if (userResult == null)
                {
                    throw new HttpStatusCodeException(
                        HttpStatusCode.NotFound, $"Such [{email}] doesn't exist");
                }

                var jwt = _tokenFormation.GetToken(userResult);

                return new ApplicationUserDTO
                {
                    FirstName = userResult.FirstName,
                    LastName = userResult.LastName,
                    DateOfBirth = userResult.DateOfBirth,
                    Email = userResult.Email,
                    Role = userResult.Role,
                    Token = jwt 
                };
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}