using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TheaterSchedule.BLL.DTOs;

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
        public string GetToken(ApplicationUserDTO user)
        {
            var claims = new List<Claim>
            {
                new Claim("user_id", user.Id),
                new Claim("firstName", user.FirstName),
                new Claim("lastName", user.LastName),
                new Claim("email", user.Email),
                new Claim("dateTimeOffset", user.DateOfBirth.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Authorization", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(issuer: _authOptions.ISSUER, audience: _authOptions.AUDIENCE, notBefore: now, claims: claimsIdentity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(_authOptions.LIFETIME)), signingCredentials: new SigningCredentials(_authOptions.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));

            return _tokenHandler.WriteToken(jwt);
        }
    }
}

