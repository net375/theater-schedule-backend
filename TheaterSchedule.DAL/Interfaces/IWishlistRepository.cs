using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IWishlistRepository
    {
        IEnumerable<int> GetPerformanceIdsInWishlist( string phoneId, string languageCode );
        Task<Wishlist> GetPerformanceByPhoneIdAndPerformanceId( string phoneId, int scheduleId );
        void Add( Wishlist performance );
        void Remove( Wishlist performance );
    }
}
