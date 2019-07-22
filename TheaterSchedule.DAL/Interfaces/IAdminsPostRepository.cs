using System.Collections.Generic;
using Entities.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IAdminsPostRepository
    {
        void Add(AdminsPost post);
        IEnumerable<AdminsPost> GetAllPersonalById(int id);
        IEnumerable<AdminsPost> GetAllPublic();
    }
}
