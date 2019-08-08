using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using TheaterSchedule.MiddlewareComponents;
using System.Threading.Tasks;

namespace TheaterSchedule.Controllers
{
    #region snippet_WishlistController    
    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(CustomAuthorizationAttribute))]
    [Authorize]
    public class WishlistController : Controller
    {
        private IWishlistService _wishlistService;

        #endregion

        public WishlistController(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        #region snippet_LoadWishlist

        /// <summary>
        /// Loads favourites user performances from database
        /// </summary>
        /// <param name="languageCode"></param>
        /// <param name="phoneId">Unique user device identifier</param>
        /// <returns>A list of favourites user performances from database</returns>
        /// <response code="200">Returns the list of favourites user performances of appropriate language</response>
        /// <response code="400">If url which you are sending is not valid</response>
        /// <response code="404">If the information about user performances is null</response>
        /// 
        [HttpGet("{phoneId}/{languageCode}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<WishlistDTO>> LoadWishlist(
            string phoneId, string languageCode)
        {

            IEnumerable<WishlistDTO> wishlist = _wishlistService.LoadWishlist(phoneId, languageCode);

            if (wishlist == null)
                return NotFound();

            return StatusCode(200, wishlist);

        }

        #endregion

        #region snippet_SaveOrDeletePerformance

        /// <summary>
        /// Sends or deletes favourite user performance to/from database
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /SaveOrDeletePerformance
        ///     {
        ///        "id": 99,
        ///        "phoneId": "qwerty12-qwer-qwer-qwer-qwerty123456",
        ///     }
        ///
        /// </remarks>
        /// <param name="performanceId"></param>
        /// <param name="phoneId">Unique user device identifier</param>
        /// <returns>A newly added performance to wishlist or information about successful operation (Save or Delete)</returns>
        /// <response code="200">A newly added performance to wishlist or information about successful operation (Save or Delete)</response>
        /// <response code="400">If url which you are sending is not valid</response>
        [HttpPost("{phoneId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SaveOrDeletePerformance(
            string phoneId, [FromQuery] int performanceId)
        {
            
               await _wishlistService.SaveOrDeletePerformance(phoneId, performanceId);
                return Ok();       
        }

        #endregion
    }
}
