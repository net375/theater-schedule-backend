using System;
using System.Collections.Generic;
using Entities.Models;
using TheaterSchedule.DAL.Interfaces;
using System.Linq;

namespace TheaterSchedule.DAL.Repositories
{
    public class AdminsPostRepository : IAdminsPostRepository
    {
        private readonly TheaterDatabaseContext db;
        
        public AdminsPostRepository(TheaterDatabaseContext context)
        {
            this.db = context;
        }

        public void Add(AdminsPost post)
        {
            this.db.AdminsPost.Add(post);
        }
        
        public IEnumerable<AdminsPost> GetAllPersonalById(int id)
        {
            return this.db.AdminsPost.Where(post => post.IsPersonal && post.ToUserId == id);
        }

        public IEnumerable<AdminsPost> GetAllPublic()
        {
            return this.db.AdminsPost.Where(post => !post.IsPersonal);
        }
    }
}
