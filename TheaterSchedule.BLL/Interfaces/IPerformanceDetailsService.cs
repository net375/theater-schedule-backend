using TheaterSchedule.BLL.DTO;
using System.Collections.Generic;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IPerformanceDetailsService
    {
        PerformanceDetailsDTO LoadPerformanceDetails( string languageCode, int id );
    }
}
