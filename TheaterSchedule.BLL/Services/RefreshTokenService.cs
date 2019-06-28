﻿using System.Threading.Tasks;
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
                RefreshToken = result.RefreshToken,
                DaysToExpire = result.DaysToExpire
            };
        }

        public async Task UpdateRefreshTokenAsync(int id, string refreshtoken, int userId, double daysToExpire)
        {
            var refreshToken = await _refreshTokenRepository.GetAsync(item => item.Id == id);

            if (refreshToken == null)
            {
                throw new HttpStatusCodeException(
                       HttpStatusCode.NotFound, $"Such refresh token doesn't exist");
            }

            refreshToken.RefreshToken = refreshtoken;
            refreshToken.DaysToExpire = DateTime.Now.AddDays(daysToExpire);

            await _refreshTokenRepository.UpdateAsync(refreshToken);
          
            await _theaterScheduleUnitOfWork.SaveAsync();
        }

        public async Task AddRefreshTokenAsync(string refreshtoken, int userId, double daysToExpire)
        {
            var refreshToken = await _refreshTokenRepository.GetAsync(item => item.RefreshToken == refreshtoken);
     
            if (refreshToken != null)
            {
                refreshToken.RefreshToken = refreshtoken;

                refreshToken.DaysToExpire = DateTime.Now.AddDays(daysToExpire);

                await _refreshTokenRepository.UpdateAsync(refreshToken);

                await _theaterScheduleUnitOfWork.SaveAsync();
            }
            else
            {
                await _refreshTokenRepository.InsertAsync(new RefreshTokens
                {
                    RefreshToken = refreshtoken,
                    UserId = userId,
                    DaysToExpire = DateTime.Now.AddDays(daysToExpire)
                });

                await _theaterScheduleUnitOfWork.SaveAsync();
            }
        }
    }
}
