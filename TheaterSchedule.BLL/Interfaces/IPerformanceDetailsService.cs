using TheaterSchedule.BLL.DTO;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IPerformanceDetailsService
    {
        PerformanceDetailsBaseDTO LoadPerformanceDetails(string Accountid, string languageCode, int id );
    }
}
