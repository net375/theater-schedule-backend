using Entities.Models;
using System.Threading.Tasks;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Repositories
{
    public class AuthorizationRepository:IAuthorizationRepository
    {
        private TheaterDatabaseContext _dbContext;

        public AuthorizationRepository(TheaterDatabaseContext context)
        {
            _dbContext = context;
        }

        public async Task<ApplicationUser> GetAsync(string email,string password)
        {
            //return await _dbContext..FirstOrDefaultAsync(predicate);
        }
    }
}
