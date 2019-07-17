using Entities.Models;
using System.Linq;
using System.Threading.Tasks;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<Account> GetUserByEmailAddress(string email);
        IQueryable<Account> GetAll();
        Task<Account> GetByIdAsync(int id);
        ApplicationUserModel GetById(int id);
        void Add(ApplicationUserModel user);
        void UpdateUser(ApplicationUserModel user);
        void Delete(int id);
        Task UpdatePasswordAsync(ChangePasswordModel model);
        Task UpdateProfileAsync(Account user);
    }
}
