using TheaterSchedule.BLL.DTOs;

namespace TheaterSchedule.Formatters
{
    public interface ITokenFormation
    {
        string GetToken(ApplicationUserDTO user);
    }
}
