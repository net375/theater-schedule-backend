using Entities.Models;
using System.Linq;
using System.Threading.Tasks;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IResetCodeRepository
    {
        Task<Account> GetUserByEmailAddress(string email);
        IQueryable<ResetCode> GetAll();
        Task<ResetCode> GetByValueAsync(int value);
        ResetCodeModel GetByValue(int value);
        void Add(ResetCodeModel resetCode);
        void Delete(int value);
    }
}
