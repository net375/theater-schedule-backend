using System.Threading.Tasks;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using Entities.Models;
using System;
using TheaterSchedule.BLL.DTOs;
using TheaterSchedule.Infrastructure;
using System.Net;
using System.Security.Cryptography;

namespace TheaterSchedule.BLL.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private IRefreshTokenRepository _refreshTokenRepository;
        private ITheaterScheduleUnitOfWork _theaterScheduleUnitOfWork;

        public RefreshTokenService(IRefreshTokenRepository refreshTokenRepository, ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork)
        {
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

        public async Task<RefreshTokenDTO> GetAsync(string refreshToken, bool isActive = true)
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

        public async Task UpdateRefreshTokenAsync(int id, string refreshtoken, int userId, double daysToExpire, bool isActive = true)
        {
            var refreshToken = await _refreshTokenRepository.GetAsync(item => item.Id == id && item.UserId == userId);

            if (refreshToken == null)
            {
                throw new HttpStatusCodeException(
                       HttpStatusCode.NotFound, $"Such refresh token doesn't exist");
            }
            
            refreshToken.IsActive = isActive;
            refreshToken.RefreshToken = refreshtoken;
            refreshToken.DaysToExpire = DateTime.Now.AddDays(daysToExpire);

            await _refreshTokenRepository.UpdateAsync(refreshToken);
          
            await _theaterScheduleUnitOfWork.SaveAsync();
        }

        public async Task AddRefreshTokenAsync(string refreshtoken, int userId, double daysToExpire)
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
                    DaysToExpire = DateTime.Now.AddDays(daysToExpire)
                });

                await _theaterScheduleUnitOfWork.SaveAsync();
            }
        }
    }
}
