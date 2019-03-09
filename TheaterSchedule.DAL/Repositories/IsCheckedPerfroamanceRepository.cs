using Entities.Models;
using System.Collections.Generic;
using System.Linq;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Repositories
{

    public class IsCheckedPerformanceRepository: IIsCheckedPerformanceRepository
    {
        private TheaterDatabaseContext db;

        public IsCheckedPerformanceRepository( TheaterDatabaseContext context )
        {
            this.db = context;
        }

        public bool IsChecked( string phoneId, int performanceId )
        {
            return (from performance in db.Performance
                    join wishlist in db.Wishlist on performance.PerformanceId equals wishlist.PerformanceId
                        into wishlist_join
                    from w in wishlist_join.DefaultIfEmpty()
                    where (w != null && w.Account.PhoneIdentifier == phoneId &&
                           (performance.PerformanceId) == performanceId)
                    select w).Any();
        }
    }
}
