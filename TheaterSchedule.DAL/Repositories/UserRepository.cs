using System.Text;
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
            db.ApplicationUser.ToListAsync();
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

        public IQueryable<ApplicationUser> GetAll()
        {
            return db.ApplicationUser;            
        }

        public async Task<ApplicationUser> GetByIdAsync(int id)
        {
             return await db.ApplicationUser.FirstOrDefaultAsync(u => u.Id == id);           
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

        public async Task<ApplicationUser> GetUserByEmailAddress(string email)
        {
           return await db.ApplicationUser.FirstOrDefaultAsync(item => item.Email == email);
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
