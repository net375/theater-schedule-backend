using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Repositories
{
    public class WishlistRepository : IWishlistRepository
    {
        private TheaterDatabaseContext db;

        public WishlistRepository(TheaterDatabaseContext context)
        {
            db = context;
        }

        public IEnumerable<WishlistDataModel> GetWishlistByPhoneIdentifier(
            string phoneId, string languageCode)
        {
            IEnumerable<WishlistDataModel> resultWishlist = null;

            resultWishlist = from account in db.Account
                             join wishlist in db.Wishlist
                                 on account.AccountId equals wishlist.AccountId
                             join performance in db.Performance
                                 on wishlist.PerformanceId equals performance.PerformanceId
                             join performanceTr in db.PerformanceTr
                                 on performance.PerformanceId equals performanceTr.PerformanceId
                             join language in db.Language
                                 on performanceTr.LanguageId equals language.LanguageId
                             where account.PhoneIdentifier == phoneId
                                   && languageCode == language.LanguageCode
                             //orderby wishlist.WishPerformanceId descending
                             select new WishlistDataModel()
                             {
                                 PerformanceId = wishlist.PerformanceId,
                                 MainImage = performance.MainImage,
                                 Title = performanceTr.Title
                             };

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