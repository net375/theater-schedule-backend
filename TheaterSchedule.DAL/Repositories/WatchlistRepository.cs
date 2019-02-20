using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Repositories
{
    public class WatchlistRepository : IWatchlistRepository
    {
        private TheaterDatabaseContext db;

        public WatchlistRepository(TheaterDatabaseContext context)
        {
            db = context;
        }

        public IEnumerable<WatchlistDataModel> GetWatchlistByPhoneIdentifier(
            string phoneId, string languageCode)
        {
            IEnumerable<WatchlistDataModel> resultWatchlist = null;

            resultWatchlist = from account in db.Account
                join watchlist in db.Watchlist
                    on account.AccountId equals watchlist.AccountId
                join performance in db.Performance
                    on watchlist.PerformanceId equals performance.PerformanceId
                join performanceTr in db.PerformanceTr
                    on performance.PerformanceId equals performanceTr.PerformanceId
                join language in db.Language
                    on performanceTr.LanguageId equals language.LanguageId
                where account.PhoneIdentifier == phoneId
                      && languageCode == language.LanguageCode
                select new WatchlistDataModel()
                {
                    PerformanceId = watchlist.PerformanceId,
                    MainImage = performance.MainImage,
                    Title = performanceTr.Title
                };

            return resultWatchlist;
        }

        public Watchlist GetPerformanceByPhoneIdAndScheduleId(
            string phoneId, int performanceId)
        {
            return db.Watchlist
                .Include(w => w.Account)
                .FirstOrDefault(a => a.Account.PhoneIdentifier == phoneId &&
                                     a.PerformanceId == performanceId);
        }

        public void Add(Watchlist performance)
        {
            db.Watchlist.Add(performance);
        }

        public void Remove(Watchlist performance)
        {
            db.Watchlist.Remove(performance);
        }
    }
}
