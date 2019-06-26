using System;
using TheaterSchedule.BLL.Helpers;
using TheaterSchedule.BLL.DTOs;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using System.Linq;
using AutoMapper;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.BLL.Services
{
    public class UserService : IUserService
    {
        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private IUserRepository userRepository;

        public UserService(ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork, IUserRepository userRepository)
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.userRepository = userRepository;
        }
        public ApplicationUserDTO Create(ApplicationUserDTO user, string password)
        {
            if (userRepository.GetAll().Any(u => u.Email == user.Email))
                throw new ArgumentException();

            byte[] passwordHash, passwordSalt;

            PasswordGenerators.CreatePasswordHash(password, out passwordHash, out passwordSalt);

                userRepository.Add(new ApplicationUserModel
                {
                    City = user.City,
                    PasswordSalt = passwordSalt,
                    Country = user.Country,
                    DateOfBirth=user.DateOfBirth,
                    Email=user.Email,
                    FirstName=user.FirstName,
                    Id=user.Id,
                    LastName=user.LastName,
                    PasswordHash=passwordHash
                });

            theaterScheduleUnitOfWork.Save();

            return user;
        }
    }
}
