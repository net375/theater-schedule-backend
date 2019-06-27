using TheaterSchedule.BLL.DTOs;

namespace TheaterSchedule.Formatters
{
    public interface ITokenFormation
    {
        string GenerateAccessToken(ApplicationUserDTO user);
        string GenerateRefreshToken(int size = 32);
    }
}
