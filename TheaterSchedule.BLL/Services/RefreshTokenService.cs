using System.Threading.Tasks;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using Entities.Models;
using System;
using TheaterSchedule.BLL.DTOs;
using TheaterSchedule.Infrastructure;
using System.Net;
using System.Security.Cryptography;
using TheaterSchedule.BLL.Models;

namespace TheaterSchedule.BLL.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private IUserService _userService;
        private IRefreshTokenRepository _refreshTokenRepository;
        private ITheaterScheduleUnitOfWork _theaterScheduleUnitOfWork;
        private ITokenService _tokenService;


        public RefreshTokenService(IRefreshTokenRepository refreshTokenRepository, ITokenService tokenService, IUserService userService, ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork)
        {
            _userService = userService;
            _tokenService = tokenService;
            _refreshTokenRepository = refreshTokenRepository;
            _theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
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

        public async Task<RefreshTokenDTO> GetAsync(string refreshToken)
        {
            var result = await _refreshTokenRepository.GetAsync(item => item.RefreshToken == refreshToken);

            if (result == null)
            {
                throw new HttpStatusCodeException(
                       HttpStatusCode.NotFound, "Such refresh token doesn't exist");
            }

            return new RefreshTokenDTO
            {
                Id = result.Id,
                UserId = result.UserId,
                IsActive = result.IsActive,
                RefreshToken = result.RefreshToken,
                DaysToExpire = result.DaysToExpire
            };
        }

        public async Task<TokensResponse> CheckRefreshTokenAsync(string inputValues)
        {
            var refreshToken = await _refreshTokenRepository.GetAsync(item => item.RefreshToken == inputValues);

            if (refreshToken == null)
            {
                throw new HttpStatusCodeException(
                    HttpStatusCode.NotFound, $"Such refreshToken doesn't exist");
            }

            if (!refreshToken.IsActive)
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

            var newRefreshToken = GenerateRefreshToken();

            var newJwt = _tokenService.GenerateAccessToken(userResult, newRefreshToken);

            await UpdateRefreshTokenAsync(refreshToken.Id, newRefreshToken, userResult.Id, Constants.DaysToExpireRefreshToken);            

            return new TokensResponse { AccessToken = newJwt, RefreshToken = newRefreshToken, ExpiresTime = DateTime.Now.AddMinutes(Constants.MinToExpireAccessToken) };
        }

        public async Task UpdateRefreshTokenAsync(int id, string refreshtoken, int userId, int daysToExpire, bool isActive = true)
        {
            var refreshToken = await _refreshTokenRepository.GetAsync(item => item.Id == id && item.UserId == userId);

            if (refreshToken == null)
            {
                throw new HttpStatusCodeException(
                       HttpStatusCode.NotFound, $"Such refresh token doesn't exist");
            }

            refreshToken.IsActive = isActive;
            refreshToken.RefreshToken = refreshtoken;
            refreshToken.DaysToExpire = DateTime.Now.AddMonths(daysToExpire);

            await _refreshTokenRepository.UpdateAsync(refreshToken);

            await _theaterScheduleUnitOfWork.SaveAsync();
        }

        public async Task AddRefreshTokenAsync(string refreshtoken, int userId, int daysToExpire)
        {
            var refreshToken = await _refreshTokenRepository.GetAsync(item => item.RefreshToken == refreshtoken && item.UserId == userId);

            if (refreshToken != null)
            {
                await UpdateRefreshTokenAsync(refreshToken.Id, refreshtoken, userId, daysToExpire);
            }
            else
            {
                await _refreshTokenRepository.InsertAsync(new RefreshTokens
                {
                    RefreshToken = refreshtoken,
                    IsActive = true,
                    UserId = userId,
                    DaysToExpire = DateTime.Now.AddMonths(daysToExpire)
                });

                await _theaterScheduleUnitOfWork.SaveAsync();
            }
        }
    }
}
