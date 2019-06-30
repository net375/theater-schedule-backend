using System;
using TheaterSchedule.BLL.Helpers;
using TheaterSchedule.BLL.DTOs;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TheaterSchedule.DAL.Models;
using System.Threading.Tasks;
using System.Net;
using TheaterSchedule.Infrastructure;
using System.Text;

namespace TheaterSchedule.BLL.Services
{
    public class UserService : IUserService
    {
        private ITheaterScheduleUnitOfWork _theaterScheduleUnitOfWork;
        private IUserRepository _userRepository;

        public UserService(ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork, IUserRepository userRepository)
        {
            _theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            _userRepository = userRepository;
        }
        
        public async Task<ApplicationUserDTO> GetByIdAsync(int id)
        {
            var user =  await _userRepository.GetByIdAsync(id);
           
            if (user == null)
            {
                throw new HttpStatusCodeException(
                       HttpStatusCode.NotFound, $"Such user doesn't exist");
            }

            return new ApplicationUserDTO
            {
                Id = user.AccountId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                City = user.City,
                Country = user.Country,
                DateOfBirth = user.Birthdate.ToString()
            };
        }

        public async Task<ApplicationUserDTO> GetAsync(string email, string passwordHash)
        {
            var user = await _userRepository.GetAll().FirstOrDefaultAsync(item => item.Email == email && item.PasswordHash == passwordHash);

            if (user == null)
            {
                throw new HttpStatusCodeException(
                       HttpStatusCode.NotFound, $"Such user doesn't exist");
            }

            return new ApplicationUserDTO
            {
                Id = user.AccountId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                City = user.City,
                Country = user.Country,
                DateOfBirth = user.Birthdate.ToString()
            };
        }

        public ApplicationUserDTO Create(ApplicationUserDTO user, string password)
        {
            if (_userRepository.GetAll().Any(u => u.Email == user.Email))
                throw new ArgumentException("Such user already exists");

            byte[] passwordHash, passwordSalt;

            PasswordGenerators.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            if (user.SettingsId == null)
                user.SettingsId = 1;

            _userRepository.Add(new ApplicationUserModel
            {
                City = user.City,
                PasswordSalt = passwordSalt,
                Country = user.Country,
                DateOfBirth = Convert.ToDateTime(user.DateOfBirth).Date,
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                PasswordHash = passwordHash,
                PhoneIdentifier = user.PhoneIdentifier,
                SettingsId = user.SettingsId.Value
            });

            _theaterScheduleUnitOfWork.Save();

            return user;
        }
    }
}