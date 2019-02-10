using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;

namespace TheaterSchedule.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class WatchlistController : Controller
    {
        private IWatchlistService watchlistService;

        public WatchlistController( IWatchlistService watchlistService )
        {
            this.watchlistService = watchlistService;
        }

        [HttpGet( "{languageCode}/{phoneIdentifier}" )]
        public IEnumerable<WatchlistDTO> GetWatchlist(
            string languageCode, string phoneIdentifier )
        {
            return watchlistService.GetWatchlist( languageCode, phoneIdentifier );
        }
    }
}
