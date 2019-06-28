using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using TheaterSchedule.BLL.DTOs;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.BLL.Models;
using Microsoft.IdentityModel.Tokens;

namespace TheaterSchedule.BLL.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtSecurityTokenHandler _tokenHandler;
        private readonly AuthOptions _authOptions;

        public TokenService(IOptions<AuthOptions> authOptions)
        {
            _authOptions = authOptions.Value;
            _tokenHandler = new JwtSecurityTokenHandler();
        }

        public string GenerateAccessToken(ApplicationUserDTO user)
        {
            var claims = new List<Claim>
            {
                new Claim("userId", user.Id.ToString()),
                new Claim("firstName", user.FirstName),
                new Claim("lastName", user.LastName),
                new Claim("email", user.Email),
                new Claim("dateTimeOffset", user.DateOfBirth.ToString())
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Authorization", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            var now = DateTime.Now;

            var jwt = new JwtSecurityToken(issuer: _authOptions.ISSUER, audience: _authOptions.AUDIENCE, notBefore: now, claims: claimsIdentity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(_authOptions.LIFETIME)), signingCredentials: new SigningCredentials(_authOptions.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));

            return _tokenHandler.WriteToken(jwt);
        }
    }
}