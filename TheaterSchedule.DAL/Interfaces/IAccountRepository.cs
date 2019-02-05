using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IAccountRepository
    {
        void Add(Account account);
        Account GetAccountByPhoneId(string phoneId);
    }
}
