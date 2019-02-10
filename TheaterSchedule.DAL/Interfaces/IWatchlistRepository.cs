using System.Collections.Generic;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IWatchlistRepository
    {
        IEnumerable<WatchlistDataModel> GetWatchlistByPhoneIdentifier(
            string languageCode, string phoneIdentifier );
    }
}
