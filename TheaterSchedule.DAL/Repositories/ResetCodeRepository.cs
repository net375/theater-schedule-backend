using System;
using System.Linq;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TheaterSchedule.DAL.Repositories
{
    public class ResetCodeRepository : IResetCodeRepository
    {
        private TheaterDatabaseContext db;

        public ResetCodeRepository(TheaterDatabaseContext context)
        {
            db = context;
        }

        public void Add(ResetCodeModel resetModel)
        {
            db.ResetCode.Add(new ResetCode
            {
                Code = resetModel.Code,
                AccountId = resetModel.AccountId,
                CreationTime = resetModel.CreationTime
            });
        }

        public void Delete(int value)
        {
            var resetCode = db.ResetCode.FirstOrDefaultAsync(r => r.Code == value);
            db.ResetCode.Remove(resetCode.Result);
        }

        public void DropPassword(Account account)
        {
            account.PasswordHash = string.Empty;
        }

        public void ResetPassword(Account account, string password)
        {
            account.PasswordHash = password;
        }

        public async Task<ResetCode> GetByValueAsync(int value)
        {
            return await db.ResetCode.SingleAsync(r => r.Code == value);
        }

        public async Task<Account> GetUserByEmailAddress(string email)
        {
            return await db.Account.FirstOrDefaultAsync(item => item.Email == email);
        }
    }
}
