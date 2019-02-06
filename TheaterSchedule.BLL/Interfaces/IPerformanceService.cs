using TheaterSchedule.BLL.DTO;
using System.Collections.Generic;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IPerformanceService
    {
        PerformanceDTO LoadPerformance( string languageCode, int id );
    }
}
