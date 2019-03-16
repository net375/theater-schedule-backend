using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface ITagRepository
    {
       Task<IEnumerable<string>> GetTagsByPerformanceId(int id);
    }
}
