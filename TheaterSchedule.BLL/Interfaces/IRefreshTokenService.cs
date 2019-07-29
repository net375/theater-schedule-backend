using System.Threading.Tasks;
using TheaterSchedule.BLL.DTOs;
using TheaterSchedule.BLL.Models;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IRefreshTokenService
    {
        Task AddRefreshTokenAsync(string refreshToken, int userId, int daysToExpire);
        string GenerateRefreshToken(int size = 32);
        Task<RefreshTokenDTO> GetAsync(string refreshToken);
        Task<TokensResponse> CheckRefreshTokenAsync(string refreshToken);
        Task UpdateRefreshTokenAsync(int id, string refreshToken, int userId, int daysToExpire, bool isActive = true);
    }
}
