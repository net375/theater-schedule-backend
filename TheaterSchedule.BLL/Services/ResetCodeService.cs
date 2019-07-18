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
            TimeSpan currentTime = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            _resetCodeRepository.Add(new ResetCodeModel
            {
                Code = random,
                AccountId = user.Result.AccountId,
                CreationTime = currentTime
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

            TimeSpan current = new TimeSpan(DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            TimeSpan limit = new TimeSpan(0, 0, 1, 0);

            if (current.Subtract(code.Result.CreationTime) > limit)
            {
                _resetCodeRepository.Delete(validationCode);
                _theaterScheduleUnitOfWork.Save();
                throw new Exception("This validation code timeout expired! Try again.");
            }

            var user = _userRepository.GetByIdAsync(code.Result.AccountId);
            _resetCodeRepository.DropPassword(user.Result);
            _resetCodeRepository.Delete(validationCode);

            _theaterScheduleUnitOfWork.Save();
        }
        public void ResetPassword(string password)
        {
            var user = _userRepository.GetAll().FirstOrDefault(u => u.PasswordHash == "");

            if (user == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.NotFound);
            }

            _resetCodeRepository.ResetPassword(user, PasswordGenerators.CreatePasswordHash(password));

            _theaterScheduleUnitOfWork.Save();
        }
    }
}
