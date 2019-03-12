using System;
using System.Collections.Generic;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using Entities.Models;
using System.Net;
using TheaterSchedule.Infrastructure;

namespace TheaterSchedule.BLL.Services
{
    public class PushTokenService : IPushTokenService
    {
        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private IAccountRepository accountRepository;
        private IPushTokenRepository pushTokenRepository;


        public PushTokenService(
            ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork, 
            IAccountRepository accountRepository,
            IPushTokenRepository pushTokenRepository)
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.accountRepository = accountRepository;
            this.pushTokenRepository = pushTokenRepository;
        }

        public IEnumerable<string> GetAllPushTokens()
        {
            throw new NotImplementedException();
        }

        public void StorePushToken(string phoneId, string pushToken)
        {
            Account account = accountRepository.GetAccountByPhoneId(phoneId);

            if (account == null)
            {
                throw new HttpStatusCodeException(
                    HttpStatusCode.NotFound, $"Account [{phoneId}] doesn't exist");
            }
            else
            {
                PushToken newToken = new PushToken { Token = pushToken, Account = account };
                pushTokenRepository.Add(newToken);
            }
            theaterScheduleUnitOfWork.Save();
        }
    }
}
