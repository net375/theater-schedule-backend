using TheaterSchedule.BLL.DTO;
using System.Collections.Generic;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IPerformanceScheduleService
    {
        PerformanceScheduleDTO LoadScheduleData(int performanceId);
    }
}
