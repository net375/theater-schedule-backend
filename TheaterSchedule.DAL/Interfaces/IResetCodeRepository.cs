using Entities.Models;
using System.Linq;
using System.Threading.Tasks;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IResetCodeRepository
    {
        Task<Account> GetUserByEmailAddress(string email);
        Task<ResetCode> GetByValueAsync(int value);
        void Add(ResetCodeModel resetCode);
        void Delete(int value);
        void DropPassword(Account account);
        void ResetPassword(Account account, string password);
    }
}
