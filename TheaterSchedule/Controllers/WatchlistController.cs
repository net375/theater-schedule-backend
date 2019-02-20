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

        [HttpGet( "{phoneId}/{languageCode}" )]
        public IEnumerable<WatchlistDTO> LoadWatchlist(
            string phoneId, string languageCode )
        {
            return watchlistService.LoadWatchlist( phoneId, languageCode );
        }

        [HttpPost( "{phoneId}" )]
        public IActionResult SaveOrDeletePerformance(
            string phoneId, [FromQuery]int performanceId )
        {
            watchlistService.SaveOrDeletePerformance( phoneId, performanceId);
            return Ok();
        }
    }
}
