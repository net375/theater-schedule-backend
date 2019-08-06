using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using TheaterSchedule.MiddlewareComponents;
using Microsoft.AspNetCore.Authorization;

namespace TheaterSchedule.Controllers
{
    #region snippet_WishlistController
    [ServiceFilter(typeof(CustomAuthorizationAttribute))]
    [Authorize]   
    [ApiController]    
    [Route("api/[controller]")]      
    public class WishlistController : Controller
    {
        private IWishlistService wishlistService;

        #endregion

        public WishlistController(IWishlistService wishlistService)
        {
            this.wishlistService = wishlistService;
        }

        #region snippet_LoadWishlist

        /// <summary>
        /// Loads favourites user performances from database
        /// </summary>
        /// <param name="languageCode"></param>
        /// <param name="AccountId">Unique user device identifier</param>
        /// <returns>A list of favourites user performances from database</returns>
        /// <response code="200">Returns the list of favourites user performances of appropriate language</response>
        /// <response code="400">If url which you are sending is not valid</response>
        /// <response code="404">If the information about user performances is null</response>         
        [HttpGet("{AccountId}/{languageCode}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<WishlistDTO>> LoadWishlist(
            string AccountId, string languageCode)
        {
            try
            {
                IEnumerable<WishlistDTO> wishlist = wishlistService.LoadWishlist(AccountId, languageCode);

                if (wishlist == null)
                    return NotFound();

                return StatusCode(200, wishlist);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
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
        /// <param name="AccountId">Unique user device identifier</param>
        /// <returns>A newly added performance to wishlist or information about successful operation (Save or Delete)</returns>
        /// <response code="200">A newly added performance to wishlist or information about successful operation (Save or Delete)</response>
        /// <response code="400">If url which you are sending is not valid</response>
        [HttpPost("{AccountId}")]
        [ServiceFilter(typeof(CustomAuthorizationAttribute))]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        public IActionResult SaveOrDeletePerformance(
            string AccountId, [FromQuery] int performanceId)
        {
            try
            {
                wishlistService.SaveOrDeletePerformance(AccountId, performanceId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        #endregion
    }
}
