using TheaterSchedule.BLL.DTO;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IPerformanceDetailsService
    {
        PerformanceDetailsBaseDTO LoadPerformanceDetails(string phoneId, string languageCode, int id );
    }
}
