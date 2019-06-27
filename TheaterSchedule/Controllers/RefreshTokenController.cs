using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TheaterSchedule.BLL;
using System.Net;
using System.Threading.Tasks;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.Formatters;
using TheaterSchedule.Infrastructure;
using TheaterSchedule.Models;

namespace TheaterSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefreshTokenController : ControllerBase
    {
        private IUserService _userService;
        private IRefreshTokenService _refreshTokenService;
        private ITokenFormation _tokenFormation;

        public RefreshTokenController(ITokenFormation tokenFormation, IRefreshTokenService refreshTokenService, IUserService userService)
        {
            _tokenFormation = tokenFormation;
            _refreshTokenService = refreshTokenService;
            _userService = userService;
        }
        /// <summary>
        ///     Refresh token in database and create access token retun refresh token and access token in response
        /// </summary>
        /// <param name="input"></param> 
        /// <returns>Refresh token and access token in response</returns>
        /// <response code="200">Returns the refresh token and access token in response</response>
        /// <response code="400">If url which you are sending is not valid</response>
        /// <response code="404">If the information about user is null and if such refresh token is not exist</response> 
        /// <summary>
        [HttpPost]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TokensResponse>> RefreshTokenAsync([FromBody] RefreshTokenModel input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var refreshToken = await _refreshTokenService.GetAsync(input.RefreshToken);

                if (refreshToken == null)
                {
                    throw new HttpStatusCodeException(
                        HttpStatusCode.BadRequest, $"Such refreshToken doesn't exist");
                }

                if (DateTime.UtcNow >= refreshToken.DaysToExpire)
                {
                    throw new HttpStatusCodeException(
                        HttpStatusCode.Unauthorized, "Such refresh token is inactive");
                }

                var userResult = await _userService.GetByIdAsync(refreshToken.UserId);

                if (userResult == null)
                {
                    throw new HttpStatusCodeException(
                        HttpStatusCode.NotFound, $"Such user doesn't exist");
                }
       
                var newJwt = _tokenFormation.GenerateAccessToken(userResult);

                var newRefreshToken = _tokenFormation.GenerateRefreshToken();
                
                await _refreshTokenService.UpdateRefreshTokenAsync(refreshToken.Id, newRefreshToken, userResult.Id, Constants.DaysToExpireRefreshToken);

                return StatusCode(200, new TokensResponse
                {
                    AccessToken = newJwt,
                    RefreshToken = newRefreshToken,
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

