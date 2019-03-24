using TheaterSchedule.BLL.DTO;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IPerformanceDetailsService
    {
        PerformanceDetailsBase LoadPerformanceDetails(string phoneId, string languageCode, int id );
    }
}
