using System.Collections.Generic;
using System.Threading.Tasks;
using TheaterSchedule.BLL.DTO;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IWishlistService
    {
        IEnumerable<WishlistDTO> LoadWishlist(
            string AccountId, string languageCode );
        void SaveOrDeletePerformance( string phoneId, int performanceId );
    }
}
