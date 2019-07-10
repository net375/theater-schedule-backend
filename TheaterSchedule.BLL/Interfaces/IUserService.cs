using System.Threading.Tasks;
using TheaterSchedule.BLL.DTOs;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUserDTO> GetByIdAsync(int id);
        Task<ApplicationUserDTO> GetAsync(string email, string password);
        ApplicationUserDTO Create(ApplicationUserDTO user, string password);
        Task UpdatePasswordAsync(ChangePasswordDTO passwordDTO);
        Task<ChangeProfileDTO> UpdateProfileAsync(ChangeProfileDTO profileDTO);
    }
}
