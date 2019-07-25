using TheaterSchedule.BLL.DTOs;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(ApplicationUserDTO user, string refreshToken);
    }
}
