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

        public IQueryable<ResetCode> GetAll()
        {
            return db.ResetCode;
        }

        public async Task<ResetCode> GetByValueAsync(int value)
        {
            return await db.ResetCode.FirstOrDefaultAsync(r => r.Code == value);
        }

        public ResetCodeModel GetByValue(int value)
        {
            ResetCode resetCode = db.ResetCode.First(r => r.Code == value);
            return new ResetCodeModel
            {
                Id = resetCode.Id,
                Code = resetCode.Code,
                AccountId = resetCode.AccountId,
                CreationTime = resetCode.CreationTime
            };
        }

        public async Task<Account> GetUserByEmailAddress(string email)
        {
            return await db.Account.FirstOrDefaultAsync(item => item.Email == email);
        }
    }
}
