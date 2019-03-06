using TheaterSchedule.BLL.DTO;
using System.Collections.Generic;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IPerformanceDetailsService
    {
        PerformanceDetailsDTOBase LoadPerformanceDetails(string phoneId, string languageCode, int id );
    }
}
