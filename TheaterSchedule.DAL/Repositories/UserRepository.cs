using System.Linq;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TheaterSchedule.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private TheaterDatabaseContext db;

        public UserRepository(TheaterDatabaseContext context)
        {
            this.db = context;
        }

        public void Add(ApplicationUserModel user)
        {
            db.Account.Add(new Account
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Birthdate = user.DateOfBirth,
                City = user.City,
                Country = user.Country,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                PhoneIdentifier = user.PhoneIdentifier,
                SettingsId = user.SettingsId,
                PhoneNumber = user.PhoneNumber,
                ValidationCode = user.ValidationCode,
                CodeCreationTime = user.CodeCreationTime
            });
        }

        public void Delete(int id)
        {
            Account user = db.Account
                .First(u => u.AccountId == id);
            db.Account.Remove(user);
        }

        public IQueryable<Account> GetAll()
        {
            return db.Account;            
        }

        public async Task<Account> GetByIdAsync(int id)
        {
             return await db.Account.FirstOrDefaultAsync(u => u.AccountId == id);           
        }

        public Account GetById(int id)
        {
            return db.Account.First(u => u.AccountId == id);
        }

        public async Task<Account> GetUserByEmailAddress(string email)
        {
           return await db.Account.FirstOrDefaultAsync(item => item.Email == email);
        }
        
        public void UpdateUser(ApplicationUserModel user)
        {
            var UpdateUser = db.Account.First(u => u.PhoneIdentifier == user.PhoneIdentifier);
            UpdateUser.Birthdate = user.DateOfBirth;
            UpdateUser.FirstName = user.FirstName;
            UpdateUser.LastName = user.LastName;
            UpdateUser.City = user.City;
            UpdateUser.Country = user.Country;
            UpdateUser.Email = user.Email;
            UpdateUser.PasswordHash = user.PasswordHash;
            UpdateUser.PhoneNumber = user.PhoneNumber;
            UpdateUser.ValidationCode = user.ValidationCode;
            UpdateUser.CodeCreationTime = user.CodeCreationTime;
        }

        public async Task UpdatePasswordAsync(ChangePasswordModel model)
        {
            var user = db.Account.FirstOrDefault(item => item.AccountId == model.Id);
            user.PasswordHash = model.Password;
        }

        public async Task UpdateProfileAsync(Account user)
        {
           db.Account.Update(user);
        }
        public async Task UpdateValidationCodeAsync(UpdateValidationCodeModel code)
        {
            var user = db.Account.FirstOrDefault(item => item.AccountId == code.Id);
            user.ValidationCode = code.ValidationCode;
            user.CodeCreationTime = code.CodeCreationTime;
        }
    }
}