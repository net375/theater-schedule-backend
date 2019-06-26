using Entities.Models;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;

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
            db.ApplicationUser.Add(new ApplicationUser
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                City = user.City,
                Country = user.Country,
                Email = user.Email,
                PasswordHash = Encoding.UTF8.GetString(user.PasswordHash),
                PasswordSalt = Encoding.UTF8.GetString(user.PasswordSalt)
            });
        }

        public void Delete(int id)
        {
            ApplicationUser user = db.ApplicationUser.First(u => u.Id == id);
            db.ApplicationUser.Remove(user);
        }

        public IEnumerable<ApplicationUserModel> GetAll()
        {
            IEnumerable<ApplicationUserModel> listOfUsers = null;
            listOfUsers = from applicationuser in db.ApplicationUser
                          select new ApplicationUserModel
                          {
                              Id = applicationuser.Id,
                              FirstName = applicationuser.FirstName,
                              LastName = applicationuser.LastName,
                              DateOfBirth = applicationuser.DateOfBirth,
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
            ApplicationUser user = db.ApplicationUser.First(u => u.Id == id);
            return new ApplicationUserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                City = user.City,
                Country = user.Country,
                Email = user.Email,
                PasswordHash = Encoding.UTF8.GetBytes(user.PasswordHash),
                PasswordSalt = Encoding.UTF8.GetBytes(user.PasswordSalt)
            };
        }

        public ApplicationUserModel GetUserByEmailAddress(string email)
        {
            ApplicationUser user = db.ApplicationUser.First(u => u.Email == email);
            return new ApplicationUserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                City = user.City,
                Country = user.Country,
                Email = user.Email,
                PasswordHash = Encoding.UTF8.GetBytes(user.PasswordHash),
                PasswordSalt = Encoding.UTF8.GetBytes(user.PasswordSalt)
            };
        }

        public void UpdateUser(ApplicationUserModel user)
        {
            db.ApplicationUser.Update(new ApplicationUser
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                City = user.City,
                Country = user.Country,
                Email = user.Email,
                PasswordHash = Encoding.UTF8.GetString(user.PasswordHash),
                PasswordSalt = Encoding.UTF8.GetString(user.PasswordSalt)
            });
        }
    }
}
