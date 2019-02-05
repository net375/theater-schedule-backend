using System.Linq;
using TheaterSchedule.DAL.Interfaces;
using Entities.Models;

namespace TheaterSchedule.DAL.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private TheaterDatabaseContext db;

        public AccountRepository(TheaterDatabaseContext context)
        {
            this.db = context;
        }

        public void Add(Account account)
        {
            db.Account.Add(account);
        }

        public Account GetAccountByPhoneId(string phoneId)
        {
            return db.Account.SingleOrDefault(a => a.PhoneIdentifier == phoneId);
        }
    }
}
