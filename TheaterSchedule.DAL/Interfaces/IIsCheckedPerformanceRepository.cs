using System.Collections.Generic;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IIsCheckedPerformanceRepository
    {
        bool IsChecked(string phoneId, int performanceId);
    }
}
