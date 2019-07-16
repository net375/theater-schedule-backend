using System.Collections.Generic;
using Entities.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IAdminsPostRepository
    {
        void Add(AdminsPost post);
        List<AdminsPost> GetAllPersonalById(int id);
        List<AdminsPost> GetAllPublic();
    }
}
