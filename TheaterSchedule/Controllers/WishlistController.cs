using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;

namespace TheaterSchedule.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class WishlistController : Controller
    {
        private IWishlistService WishlistService;

        public WishlistController( IWishlistService WishlistService )
        {
            this.WishlistService = WishlistService;
        }

        [HttpGet( "{phoneId}/{languageCode}" )]
        public IEnumerable<WishlistDTO> LoadWishlist(
            string phoneId, string languageCode )
        {
            return WishlistService.LoadWishlist( phoneId, languageCode );
        }

        [HttpPost( "{phoneId}" )]
        public IActionResult SaveOrDeletePerformance(
            string phoneId, [FromQuery]int performanceId )
        {
            WishlistService.SaveOrDeletePerformance( phoneId, performanceId);
            return Ok();
        }
    }
}
