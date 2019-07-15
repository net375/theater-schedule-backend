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
    public class ResetCodeService : IResetCodeService
    {
        private IResetCodeRepository _resetCodeRepository;
        private ITheaterScheduleUnitOfWork _theaterScheduleUnitOfWork;
        private IUserRepository _userRepository;
        private IEmailService _emailService;

        public ResetCodeService(ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork, IResetCodeRepository resetCodeRepository, IUserRepository userRepository, IEmailService emailService)
        {
            _theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            _resetCodeRepository = resetCodeRepository;
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public async Task<ResetCodeDTO> GetByValueAsync(int value)
        {
            var resetCode = await _resetCodeRepository.GetByValueAsync(value);

            if (resetCode == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.NotFound, $"Such rest code doesn't exists");
            }

            return new ResetCodeDTO
            {
                Id = resetCode.Id,
                Code = resetCode.Code
            };
        }

        public void GenerateResetCodeAsync(string email)
        {
            var user = _resetCodeRepository.GetUserByEmailAddress(email);

            if (user == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.NotFound, $"Such user doesn't exist");
            }

            int random = new Random().Next(1000, 9999);

            _resetCodeRepository.Add(new ResetCodeModel
            {
                Code = random,
                AccountId = user.Result.AccountId
            });

            _emailService.SendEmailAsync(email, "noreply", $"Verification code for resetting your password: {random}");

            _theaterScheduleUnitOfWork.Save();
        }

        public void ValidateCode(int validationCode)
        {
            var code = _resetCodeRepository.GetByValueAsync(validationCode);

            if (code == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.NotFound);
            }

            _resetCodeRepository.Delete(validationCode);

            var user = _userRepository.GetById(code.Result.AccountId);
            _userRepository.UpdateUser(new ApplicationUserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                SettingsId = user.SettingsId,
                PhoneNumber = user.PhoneNumber,
                PhoneIdentifier = user.PhoneIdentifier,
                PasswordHash = "",
                City = user.City,
                Country = user.Country
            });

            _theaterScheduleUnitOfWork.Save();
        }
        public void ResetPassword(string password)
        {
            var user = _userRepository.GetAll().FirstOrDefaultAsync(u => u.PasswordHash == "");

            if (user == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.NotFound);
            }

            _userRepository.UpdateUser(new ApplicationUserModel
            {
                Id = user.Result.AccountId,
                FirstName = user.Result.FirstName,
                LastName = user.Result.LastName,
                Email = user.Result.Email,
                DateOfBirth = user.Result.Birthdate,
                SettingsId = user.Result.SettingsId.Value,
                PhoneNumber = user.Result.PhoneNumber,
                PhoneIdentifier = user.Result.PhoneIdentifier,
                PasswordHash = PasswordGenerators.CreatePasswordHash(password),
                City = user.Result.City,
                Country = user.Result.Country
            });

            _theaterScheduleUnitOfWork.Save();
        }
    }
}
