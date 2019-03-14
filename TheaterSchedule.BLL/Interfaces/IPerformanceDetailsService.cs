using TheaterSchedule.BLL.DTO;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IPerformanceDetailsService
    {
        PerformanceDetailsDTOBase LoadPerformanceDetails(string phoneId, string languageCode, int id );
    }
}
