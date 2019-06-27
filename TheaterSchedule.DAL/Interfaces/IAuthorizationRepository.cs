using Entities.Models;
using System.Threading.Tasks;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IAuthorizationRepository
    {
        Task<Account> GetAsync(string email,string password);
    }
}
