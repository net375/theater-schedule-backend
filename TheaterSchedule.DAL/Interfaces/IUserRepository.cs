using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<ApplicationUserModel> GetUserByEmailAddress(string email);
        IEnumerable<ApplicationUserModel> GetAll();
        ApplicationUserModel GetById(int id);
        void Add(ApplicationUserModel user);
        void UpdateUser(ApplicationUserModel user);
        void Delete(int id);
    }
}
