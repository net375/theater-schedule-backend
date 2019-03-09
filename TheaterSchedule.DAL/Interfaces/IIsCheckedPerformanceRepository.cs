using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IIsCheckedPerformanceRepository
    {
        bool IsChecked(string phoneId, int performanceId);
    }
}
