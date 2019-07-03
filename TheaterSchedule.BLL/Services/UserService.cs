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
        private ISettingsRepository _settingsRepository;

        public UserService(ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork, IUserRepository userRepository, ISettingsRepository settingsRepository)
        {
            _theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            _userRepository = userRepository;
            _settingsRepository = settingsRepository;
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
                PnoneNumber = user.PnoneNumber,
                DateOfBirth = user.Birthdate.ToString()
            };
        }

        public async Task<ApplicationUserDTO> GetAsync(string email, string passwordHash)
        {
            var listOfUser = await _userRepository.GetAll().FirstOrDefaultAsync(item => item.Email == email);

            if (PasswordGenerators.VerifyPasswordHash(passwordHash, Encoding.UTF8.GetBytes(listOfUser.PasswordHash), Encoding.UTF8.GetBytes(listOfUser.PasswordSalt)))
            {
                throw new HttpStatusCodeException(
                       HttpStatusCode.NotFound, $"Such user doesn't exist");
            }

            return new ApplicationUserDTO
            {
                Id = listOfUser.AccountId,
                FirstName = listOfUser.FirstName,
                LastName = listOfUser.LastName,
                Email = listOfUser.Email,
                City = listOfUser.City,
                PnoneNumber = listOfUser.PnoneNumber,
                Country = listOfUser.Country,
                DateOfBirth = listOfUser.Birthdate.ToString()
            };
        }

        public ApplicationUserDTO Create(ApplicationUserDTO user, string password)
        {
            if (_userRepository.GetAll().Any(u => u.Email == user.Email))
                throw new ArgumentException("Such user already exists");

            byte[] passwordHash, passwordSalt;

            PasswordGenerators.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.SettingsId = _settingsRepository.GetSettingsByPhoneId(user.PhoneIdentifier).SettingsId;
            user.Id = _userRepository.GetAll().First(u => u.PhoneIdentifier == user.PhoneIdentifier).AccountId;

            _userRepository.UpdateUser(new ApplicationUserModel
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
                SettingsId = user.SettingsId.Value,
                PhoneNumber = user.PnoneNumber,
                PhoneIdentifier = user.PhoneIdentifier
            });

            _theaterScheduleUnitOfWork.Save();

            return user;
        }
    }
}
