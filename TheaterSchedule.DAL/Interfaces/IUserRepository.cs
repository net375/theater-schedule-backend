using Entities.Models;
using System.Linq;
using System.Threading.Tasks;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetUserByEmailAddress(string email);
        IQueryable<ApplicationUser> GetAll();
        Task<ApplicationUser> GetByIdAsync(int id);
        ApplicationUserModel GetById(int id);
        void Add(ApplicationUserModel user);
        void UpdateUser(ApplicationUserModel user);
        void Delete(int id);
    }
}
