using System.Net;
using System.Threading.Tasks;
using TheaterSchedule.BLL.DTOs;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.Infrastructure;

namespace TheaterSchedule.BLL.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private IAuthorizationRepository _authorizationRepository;

        public AuthorizationService(IAuthorizationRepository authorizationRepository, ICacheProvider cacheProvider)
        {
            _authorizationRepository = authorizationRepository; 
        }

        public async Task<ApplicationUserDTO> GetUserAsync(string email, string password)
        {
            var user = await _authorizationRepository.GetAsync(email, password);

            if (user == null)
            {
                throw new HttpStatusCodeException(
                       HttpStatusCode.NotFound, $"Such [{email}] doesn't exist");
            }

            var response = new ApplicationUserDTO();
            //{
            //    FirstName = user.FirstName,
            //    Id = user.Id,
            //    Role = user.Role.ToString()
            //};

            return response;
        }
    }
}