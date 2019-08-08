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

        public bool IsChecked( string Accountid, int performanceId)
        {
            return (from account in db.Account
                    join wishlist in db.Wishlist on account.AccountId equals wishlist.AccountId
                    where account.AccountId == int.Parse(Accountid) && wishlist.PerformanceId == performanceId
                    select account).Any();
        }
    }
}
