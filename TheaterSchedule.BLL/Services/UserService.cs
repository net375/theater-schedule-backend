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
        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private IUserRepository userRepository;

        public UserService(ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork, IUserRepository userRepository)
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.userRepository = userRepository;
        }
        
        public async Task<ApplicationUserDTO> GetByIdAsync(int id)
        {
            var user =  await userRepository.GetByIdAsync(id);
           
            if (user == null)
            {
                throw new HttpStatusCodeException(
                       HttpStatusCode.NotFound, $"Such user doesn't exist");
            }

            return new ApplicationUserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                City = user.City,
                Country = user.Country,
                DateOfBirth = user.DateOfBirth
            };
        }

        public async Task<ApplicationUserDTO> GetAsync(string email, string passwordHash)
        {
            var user = await userRepository.GetAll().FirstOrDefaultAsync(item => item.Email == email && item.PasswordHash == passwordHash);

            if (user == null)
            {
                throw new HttpStatusCodeException(
                       HttpStatusCode.NotFound, $"Such [{email}] doesn't exist");
            }

            return new ApplicationUserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                City = user.City,
                Country = user.Country,
                DateOfBirth = user.DateOfBirth
            };
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
