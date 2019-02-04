using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheaterSchedule.DAL.Contexts;
using TheaterSchedule.DAL.Entities;
using TheaterSchedule.DAL.Interfaces;

namespace TheaterSchedule.DAL.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private TheaterScheduleContext db;

        public AccountRepository(TheaterScheduleContext context)
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
