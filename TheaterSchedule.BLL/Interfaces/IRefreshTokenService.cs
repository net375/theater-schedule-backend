﻿using System.Threading.Tasks;
using TheaterSchedule.BLL.DTOs;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IRefreshTokenService
    {
        Task AddRefreshTokenAsync(string refreshToken, int userId, double daysToExpire);
        Task<RefreshTokenDTO> GetAsync(string refreshToken);
        Task UpdateRefreshTokenAsync(int id, string refreshToken, int userId, double daysToExpire);
    }
}
