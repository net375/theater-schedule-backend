using System.Threading.Tasks;
using TheaterSchedule.BLL.DTOs;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IAuthorizationService
    {
        Task<ApplicationUserDTO> GetUserAsync(string email, string password);
    }
}
