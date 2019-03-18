using System.Threading.Tasks;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IPerformanceScheduleRepository
    {
        Task<PerformanceScheduleDataModel> GetPerfomanceScheduleInfo(int performanceId);
    }
}
