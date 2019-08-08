using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IWishlistRepository
    {
        IEnumerable<int> GetPerformanceIdsInWishlist( string AccountId, string languageCode );
        Task<Wishlist> GetPerformanceByPhoneIdAndPerformanceId( string AccountId, int scheduleId );
        void Add( Wishlist performance );
        void Remove( Wishlist performance );
    }
}
