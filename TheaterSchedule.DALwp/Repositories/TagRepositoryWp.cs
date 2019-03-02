using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.DAL.Interfaces;
using System.Threading.Tasks;
using WordPressPCL;
using WordPressPCL.Models;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DALwp.Repositories
{
   public class TagRepositoryWp : Repository, ITagRepository
    {
        public async Task<Tag> GetTagById(int id)
        {
            return await InitializeClient().Tags.GetByID(id); ;
        }
    }
}
