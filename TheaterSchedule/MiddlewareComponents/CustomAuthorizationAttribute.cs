using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;
using TheaterSchedule.BLL;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.Infrastructure;
using System.Net;

namespace TheaterSchedule.MiddlewareComponents
{
    public class CustomAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        private IRefreshTokenService _refreshTokenService;

        public CustomAuthorizationAttribute(IRefreshTokenService refreshTokenService)
        {
            _refreshTokenService = refreshTokenService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var accessToken = context.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);

            accessToken = accessToken == "null" ? null : accessToken;

            if (String.IsNullOrEmpty(accessToken))
                throw new HttpStatusCodeException(HttpStatusCode.Unauthorized);

            var authToken = new JwtSecurityToken(accessToken);

            if (Convert.ToDateTime(authToken.Claims.First(c => c.Type == ClaimKeys.ExpiresTime).Value) < DateTime.Now)
            {
                var refreshToken = authToken.Claims.First(c => c.Type == ClaimKeys.RefreshToken).Value;
                var newTokens = _refreshTokenService.CheckRefreshTokenAsync(refreshToken).GetAwaiter().GetResult();
                context.HttpContext.Response.Headers.Add("newAccess_token", newTokens.AccessToken);
                context.HttpContext.Request.Headers["Authorization"] = "Bearer " + newTokens.AccessToken;
            }
        }
    }
}
