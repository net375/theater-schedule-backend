using System.Collections.Generic;
using TheaterSchedule.BLL.DTO;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IWatchlistService
    {
        IEnumerable<WatchlistDTO> GetWatchlist(
            string languageCode, string phoneIdentifier );
    }
}
