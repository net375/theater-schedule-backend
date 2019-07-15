using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TheaterSchedule.BLL;
using System.Net;
using System.Threading.Tasks;
using TheaterSchedule.BLL.Interfaces;
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
        private ITokenService _tokenService;

        public RefreshTokenController(ITokenService tokenService, IRefreshTokenService refreshTokenService, IUserService userService)
        {
            _tokenService = tokenService;
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
        public async Task<ActionResult<TokensResponse>> UpdateRefreshTokenAsync([FromBody] RefreshTokenModel input)
        {
                var refreshToken = await _refreshTokenService.GetAsync(input.RefreshToken);

                if (refreshToken == null)
                {
                    throw new HttpStatusCodeException(
                        HttpStatusCode.NotFound, $"Such refreshToken doesn't exist");
                }

                if(!refreshToken.IsActive)
                {
                    throw new HttpStatusCodeException(
                        HttpStatusCode.Unauthorized, "Such refresh token is inactive");
                }

                if (DateTime.Now >= refreshToken.DaysToExpire)
                {
                    throw new HttpStatusCodeException(
                        HttpStatusCode.Unauthorized, "Days to expire of refresh token is inactive");
                }

                var userResult = await _userService.GetByIdAsync(refreshToken.UserId);

                if (userResult == null)
                {
                    throw new HttpStatusCodeException(
                        HttpStatusCode.NotFound, $"Such user doesn't exist");
                }
       
                var newJwt = _tokenService.GenerateAccessToken(userResult);

                var newRefreshToken = _refreshTokenService.GenerateRefreshToken();
                
                await _refreshTokenService.UpdateRefreshTokenAsync(refreshToken.Id, newRefreshToken, userResult.Id, Constants.DaysToExpireRefreshToken);

                return StatusCode(200, new TokensResponse
                {
                    AccessToken = newJwt,
                    RefreshToken = newRefreshToken,
                    ExpiresTime = DateTime.UtcNow.AddMinutes(Constants.MinToExpireAccessToken)
                });              
            }
        

        // <summary>
        //     Updates Refresh Token by making it inactive and return Ok() in response
        // </summary>
        // <param name="input"></param> 
        // <returns> StatusCodes.Status200OK in response</returns>
        // <response code="200">Returns Ok() in response</response>
        // <response code="400">If url which you are sending is not valid</response>
        // <response code="404">If the refresh token is not exist</response> 
        // <summary>
        [HttpDelete]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TokensResponse>> DeleteRefreshTokenAsync([FromBody] RefreshTokenModel input)
        {
            var refreshToken = await _refreshTokenService.GetAsync(input.RefreshToken);

            if (refreshToken == null)
            {
                throw new HttpStatusCodeException(
                    HttpStatusCode.NotFound, $"Such refreshToken doesn't exist");
            }

            var userResult = await _userService.GetByIdAsync(refreshToken.UserId);

            if (userResult == null)
            {
                throw new HttpStatusCodeException(
                    HttpStatusCode.NotFound, $"Such user doesn't exist");
            }

            await _refreshTokenService.UpdateRefreshTokenAsync(refreshToken.Id, input.RefreshToken, userResult.Id, Constants.DaysToExpireRefreshToken, false);

            return StatusCode(200);
        }
    }
}

