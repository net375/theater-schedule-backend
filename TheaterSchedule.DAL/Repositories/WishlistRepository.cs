using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
using Microsoft.Extensions.Caching.Memory;

namespace TheaterSchedule.DAL.Repositories
{
    public class WishlistRepository : IWishlistRepository
    {
        private TheaterDatabaseContext db;

        public WishlistRepository(TheaterDatabaseContext context)
        {
            db = context;
        }

        public IEnumerable<int> GetPerformanceIdsInWishlist(string phoneId, string languageCode)
        {
            var resultWishlist = from account in db.Account
                                 join wishlist in db.Wishlist
                                     on account.AccountId equals wishlist.AccountId
                                 where account.PhoneIdentifier == phoneId
                                 orderby wishlist.WishPerformanceId descending
                                 select wishlist.PerformanceId;

            return resultWishlist;
        }

        public Wishlist GetPerformanceByPhoneIdAndPerformanceId(
            string phoneId, int performanceId)
        {
            return db.Wishlist
                .Include(w => w.Account)
                .FirstOrDefault(a => a.Account.PhoneIdentifier == phoneId &&
                                     a.PerformanceId == performanceId);
        }

        public void Add(Wishlist performance)
        {
            db.Wishlist.Add(performance);
        }

        public void Remove(Wishlist performance)
        {
            db.Wishlist.Remove(performance);
        }
    }
}
