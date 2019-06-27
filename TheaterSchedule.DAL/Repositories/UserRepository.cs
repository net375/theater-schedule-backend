using Entities.Models;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
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
                AccountId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Birthdate = user.DateOfBirth,
                City = user.City,
                Country = user.Country,
                Email = user.Email,
                PasswordHash = Encoding.UTF8.GetString(user.PasswordHash),
                PasswordSalt = Encoding.UTF8.GetString(user.PasswordSalt),
                PhoneIdentifier = user.PhoneIdentifier,
                SettingsId = user.SettingsId
            });
        }

        public void Delete(int id)
        {
            Account user = db.Account
                .First(u => u.AccountId == id);
            db.Account.Remove(user);
        }

        public IEnumerable<ApplicationUserModel> GetAll()
        {
            IEnumerable<ApplicationUserModel> listOfUsers = null;
            listOfUsers = from applicationuser in db.Account
                          select new ApplicationUserModel
                          {
                              Id = applicationuser.AccountId,
                              FirstName = applicationuser.FirstName,
                              LastName = applicationuser.LastName,
                              DateOfBirth = applicationuser.Birthdate,
                              City = applicationuser.City,
                              Country = applicationuser.Country,
                              Email = applicationuser.Email,
                              PasswordHash = Encoding.UTF8.GetBytes(applicationuser.PasswordHash),                          
                              PasswordSalt = Encoding.UTF8.GetBytes(applicationuser.PasswordSalt)
                          };
            return listOfUsers;
        }

        public ApplicationUserModel GetById(int id)
        {
            Account user = db.Account.First(u => u.AccountId == id);
            return new ApplicationUserModel
            {
                Id = user.AccountId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.Birthdate,
                City = user.City,
                Country = user.Country,
                Email = user.Email,
                PasswordHash = Encoding.UTF8.GetBytes(user.PasswordHash),
                PasswordSalt = Encoding.UTF8.GetBytes(user.PasswordSalt)
            };
        }

        public async Task<ApplicationUserModel> GetUserByEmailAddress(string email)
        {
            Account user = await db.Account.FirstOrDefaultAsync(u => u.Email == email);
            return new ApplicationUserModel
            {
                Id = user.AccountId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.Birthdate,
                City = user.City,
                Country = user.Country,
                Email = user.Email,
                PasswordHash = Encoding.UTF8.GetBytes(user.PasswordHash),
                PasswordSalt = Encoding.UTF8.GetBytes(user.PasswordSalt)
            };
        }

        public void UpdateUser(ApplicationUserModel user)
        {
            db.Account.Update(new Account
            {
                AccountId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Birthdate = user.DateOfBirth,
                City = user.City,
                Country = user.Country,
                Email = user.Email,
                PasswordHash = Encoding.UTF8.GetString(user.PasswordHash),
                PasswordSalt = Encoding.UTF8.GetString(user.PasswordSalt)
            });
        }
    }
}
