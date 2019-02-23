using System.Collections.Generic;
using TheaterSchedule.BLL.DTO;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IWishlistService
    {
        IEnumerable<WishlistDTO> LoadWishlist(
            string phoneId, string languageCode );
        void SaveOrDeletePerformance( string phoneId, int performanceId );
    }
}
