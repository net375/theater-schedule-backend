using TheaterSchedule.BLL.DTO;
using System.Collections.Generic;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IPerformanceScheduleService
    {
        PerformanceSchedule LoadScheduleData(int performanceId);
    }
}
