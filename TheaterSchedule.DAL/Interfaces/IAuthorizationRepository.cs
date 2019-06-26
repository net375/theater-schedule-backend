using System.Threading.Tasks;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IAuthorizationRepository
    {
        Task<ApplicationUser> GetAsync(string email,string password);
    }
}
