using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheaterSchedule.DAL.Interfaces;

namespace TheaterSchedule.DAL.Repositories
{
    public class WishlistRepository : IWishlistRepository
    {
        private readonly TheaterDatabaseContext db;

        public WishlistRepository(TheaterDatabaseContext context)
        {
            db = context;
        }

        public IEnumerable<int> GetPerformanceIdsInWishlist(string AccountId, string languageCode)
        {
            var resultWishlist = from account in db.Account
                                 join wishlist in db.Wishlist
                                     on account.AccountId equals wishlist.AccountId
                                 where account.AccountId == int.Parse(AccountId)
                                 orderby wishlist.WishPerformanceId descending
                                 select wishlist.PerformanceId;

            return resultWishlist;
        }

        public async Task<Wishlist> GetPerformanceByPhoneIdAndPerformanceId(
            string AccountId, int performanceId)
        {
                return await db.Wishlist
                    .Include(w => w.Account)
                    .FirstOrDefaultAsync(a => a.Account.AccountId == int.Parse(AccountId) &&
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