using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.BLL;
using TheaterSchedule.Formatters;
using TheaterSchedule.Infrastructure;
using TheaterSchedule.Models;

namespace TheaterSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private IUserService _userService;
        private ITokenFormation _tokenFormation;
        private IRefreshTokenService _refreshTokenService;

        public AuthorizationController(IUserService userService, ITokenFormation tokenFormation, IRefreshTokenService refreshTokenService)
        {            
            _userService = userService;
            _tokenFormation = tokenFormation;
            _refreshTokenService = refreshTokenService;
        }


        /// <summary>
        ///     Authorization user in database and retun information about user in access token and refresh token in response
        /// </summary>
        /// <param name="input"></param> 
        /// <returns>Information about user in response and token</returns>
        /// <response code="200">Returns the information about user  and token</response>
        /// <response code="400">If url which you are sending is not valid</response>
        /// <response code="404">If the information about user is null</response> 
        [HttpPost]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TokensResponse>> AuthorizationAsync([FromBody] UserLoginModel input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var userResult = await _userService.GetAsync(input.Email, input.PasswordHash);

                if (userResult == null)
                {
                    throw new HttpStatusCodeException(
                        HttpStatusCode.NotFound, $"Such [{input.Email}] doesn't exist");
                }

                var jwt = _tokenFormation.GenerateAccessToken(userResult);

                var refreshToken = _tokenFormation.GenerateRefreshToken();

                await _refreshTokenService.AddRefreshTokenAsync(refreshToken, userResult.Id, Constants.DaysToExpireRefreshToken);

                return StatusCode(200, new TokensResponse
                {
                    AccessToken = jwt,
                    RefreshToken = refreshToken,
                    ExpiresTime = DateTime.UtcNow.AddMinutes(Constants.MinToExpireAccessToken)
                });
                
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}