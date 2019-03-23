using Entities.Models;
using System.Linq;
using TheaterSchedule.DAL.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using TheaterSchedule.DAL.Models;
using System.Collections.Generic;

namespace TheaterSchedule.DAL.Repositories
{

    public class IsCheckedPerformanceRepository: IIsCheckedPerformanceRepository
    {
        private TheaterDatabaseContext db;

        public IsCheckedPerformanceRepository( TheaterDatabaseContext context )
        {
            this.db = context;
        }

        public bool IsChecked( string phoneId, int performanceId, List<PerformanceDataModel> performances)
        {
            return (from performance in performances
                    join wishlist in db.Wishlist on performance.PerformanceId equals wishlist.PerformanceId
                    join account in db.Account on wishlist.AccountId equals account.AccountId
                        into wishlist_join
                    from w in wishlist_join.DefaultIfEmpty()
                    where (w != null && w.PhoneIdentifier == phoneId &&
                           (performance.PerformanceId) == performanceId)
                    select w).Any();
        }
    }
}
