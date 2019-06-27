using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TheaterSchedule.BLL.DTOs;
using TheaterSchedule.Models;
using System.Security.Cryptography;

namespace TheaterSchedule.Formatters
{
    public class TokenFormation : ITokenFormation
    {
        private readonly JwtSecurityTokenHandler _tokenHandler;
        private readonly AuthOptions _authOptions;

        public TokenFormation(IOptions<AuthOptions> authOptions)
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

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(issuer: _authOptions.ISSUER, audience: _authOptions.AUDIENCE, notBefore: now, claims: claimsIdentity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(_authOptions.LIFETIME)), signingCredentials: new SigningCredentials(_authOptions.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));

            return _tokenHandler.WriteToken(jwt);
        }

        public string GenerateRefreshToken(int size = 32)
        {
            var randomNumber = new byte[size];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}

