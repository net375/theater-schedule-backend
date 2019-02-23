using Entities.Models;
using System.Collections.Generic;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IWishlistRepository
    {
        IEnumerable<WishlistDataModel> GetWishlistByPhoneIdentifier(
            string phoneId, string languageCode );
        Wishlist GetPerformanceByPhoneIdAndPerformanceId( 
            string phoneId, int scheduleId );
        void Add( Wishlist performance );
        void Remove( Wishlist performance );
    }
}
