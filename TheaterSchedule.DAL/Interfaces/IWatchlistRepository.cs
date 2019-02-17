using Entities.Models;
using System.Collections.Generic;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IWatchlistRepository
    {
        IEnumerable<WatchlistDataModel> GetWatchlistByPhoneIdentifier(
            string phoneId, string languageCode );
        Watchlist GetPerformanceByPhoneIdAndScheduleId( 
            string phoneId, int scheduleId );
        void Add( Watchlist performance );
        void Remove( Watchlist performance );
    }
}
