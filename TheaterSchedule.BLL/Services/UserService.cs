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
                PhoneNumber = user.PhoneNumber,
                DateOfBirth = user.Birthdate.ToString("yyyy-MM-dd"),
                Password = user.PasswordHash
            };
        }

        public async Task<ApplicationUserDTO> GetAsync(string email, string passwordHash)
        {
            var user = await _userRepository.GetAll().FirstOrDefaultAsync(item => item.Email == email);
            
            if(user == null)            
                throw new HttpStatusCodeException(
                       HttpStatusCode.NotFound, $"Such user doesn't exist");
            

            if (!(PasswordGenerators.CreatePasswordHash(passwordHash) == user.PasswordHash))            
                throw new HttpStatusCodeException(
                       HttpStatusCode.NotFound, $"Such user doesn't exist");
            

            return new ApplicationUserDTO
            {
                Id = user.AccountId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                City = user.City,
                PhoneNumber = user.PhoneNumber,
                Country = user.Country,
                DateOfBirth = user.Birthdate.ToString("yyyy-MM-dd")
            };
        }

        public ApplicationUserDTO Create(ApplicationUserDTO user, string password)
        {
            if (_userRepository.GetAll().Any(u => u.Email == user.Email))
                throw new ArgumentException("Such user already exists");           
            
            user.SettingsId = _settingsRepository.GetSettingsByPhoneId(user.PhoneIdentifier).SettingsId;
            user.Id = _userRepository.GetAll().First(u => u.PhoneIdentifier == user.PhoneIdentifier).AccountId;

            _userRepository.UpdateUser(new ApplicationUserModel
            {
                City = user.City,
                Country = user.Country,
                DateOfBirth = Convert.ToDateTime(user.DateOfBirth).Date,
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                PasswordHash = PasswordGenerators.CreatePasswordHash(password),
                SettingsId = user.SettingsId.Value,
                PhoneNumber = user.PhoneNumber,
                PhoneIdentifier = user.PhoneIdentifier
            });

            _theaterScheduleUnitOfWork.Save();

            return user;
        }

        public async Task UpdatePasswordAsync(ChangePasswordDTO passwordDTO)
        {
            var user = await _userRepository.GetByIdAsync(passwordDTO.Id);
            if (user == null)
                throw new HttpStatusCodeException(HttpStatusCode.NotFound, $"Wrong user Id");

            var oldPasswordHash = PasswordGenerators.CreatePasswordHash(passwordDTO.OldPassword);
            if (user.PasswordHash != oldPasswordHash)
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Wrong user Password");

            await _userRepository.UpdatePasswordAsync(new ChangePasswordModel
            {
                Id = passwordDTO.Id,
                Password = PasswordGenerators.CreatePasswordHash(passwordDTO.NewPassword)
            });
            _theaterScheduleUnitOfWork.Save();
        }

        public async Task<ChangeProfileDTO> UpdateProfileAsync(ChangeProfileDTO profileDTO)
        {
            var user = await _userRepository.GetByIdAsync(profileDTO.Id);
            if (user == null)
                throw new HttpStatusCodeException(HttpStatusCode.NotFound, $"Wrong user Id");

            user.FirstName = profileDTO.FirstName;
            user.LastName = profileDTO.LastName;
            user.Birthdate = Convert.ToDateTime(profileDTO.DateOfBirth).Date;
            user.City = profileDTO.City;
            user.Country = profileDTO.Country;
            user.Email = profileDTO.Email;
            user.PhoneNumber = profileDTO.PhoneNumber;

            await _userRepository.UpdateProfileAsync(user);
            _theaterScheduleUnitOfWork.Save();
            return profileDTO;
        }
    }
}
