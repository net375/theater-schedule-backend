using System.Collections.Generic;
using TheaterSchedule.BLL.DTO;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IWatchlistService
    {
        IEnumerable<WatchlistDTO> LoadWatchlist(
            string phoneId, string languageCode );
        void SaveOrDeletePerformance( string phoneId, int performanceId );
    }
}
