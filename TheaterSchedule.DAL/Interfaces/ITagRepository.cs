using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WordPressPCL.Models;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface ITagRepository
    {
       Task<IEnumerable<string>> GetTagsByPerformanceId(int id);
    }
}
