using System;
using TheaterSchedule.BLL.Helpers;
using TheaterSchedule.BLL.DTOs;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using System.Linq;
using TheaterSchedule.DAL.Models;

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
        public ApplicationUserDTO Create(ApplicationUserDTO user, string password)
        {
            if (_userRepository.GetAll().Any(u => u.Email == user.Email))
                throw new ArgumentException("Such user already exists");

            byte[] passwordHash, passwordSalt;

            PasswordGenerators.CreatePasswordHash(password, out passwordHash, out passwordSalt);

                _userRepository.Add(new ApplicationUserModel
                {
                    City = user.City,
                    PasswordSalt = passwordSalt,
                    Country = user.Country,
                    DateOfBirth=user.DateOfBirth,
                    Email=user.Email,
                    FirstName=user.FirstName,
                    Id=user.Id,
                    LastName=user.LastName,
                    PasswordHash=passwordHash,
                    PhoneIdentifier = user.PhoneIdentifier,
                    SettingsId=user.SettingsId
                });

            _theaterScheduleUnitOfWork.Save();

            return user;
        }
    }
}
