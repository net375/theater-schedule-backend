using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using Microsoft.AspNetCore.Http;

namespace TheaterSchedule.Controllers
{
    #region snippet_ImageController

    [Obsolete]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        IImageService imageService;

        #endregion

        public ImageController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        #region snippet_GetImage

        /// <summary>
        /// Get image and converts it from "varbinary" type to "base64" format
        /// </summary>
        /// <param name="performanceId"></param>
        /// <returns>image in "base64" format</returns>
        /// <response code="200">Returns the image in "base64" format</response>
        /// <response code="404">If the image is not found</response> 
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ImageBase64>> GetImage(int performanceId)
        {
            ImageBytes image =
                await imageService.LoadPerformanceMainImageBytesAsync(performanceId);
            if (image != null)
            {
                ImageBase64 imageBase64 = new ImageBase64()
                {
                    Image = imageService.ImageToBase64(image.Image),
                    ImageFormat = image.ImageFormat
                };

                return imageBase64;
            }

            return NotFound();
        }

        #endregion

        #region snippet_GetImage

        /// <summary>
        /// Get gallery images and converts it from "varbinary" type to "base64" format
        /// </summary>
        /// <param name="performanceId"></param>
        /// <returns>image in "base64" format</returns>
        [HttpGet("GetGalleryImages")]
        [Produces("application/json")]
        public async Task<ActionResult<List<ImageBase64>>> GetGalleryImages(int performanceId)
        {
            List<ImageBase64> result = null;
            List<ImageBytes> images =
                await imageService.LoadPerformanceGalleryBytesAsync(performanceId);

            await Task.Run(() =>
            {
                result = images.Select(image => new ImageBase64()
                {
                    Image = imageService.ImageToBase64(image.Image),
                    ImageFormat = image.ImageFormat
                }).ToList();
            });

            return result;
        }

        #endregion

        #region snippet_GetAsFile

        /// <summary>
        /// Get image as file
        /// </summary>
        /// <param name="performanceId"></param>
        /// <returns>image as file</returns>
        [HttpGet("GetAsFile")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsFile(int performanceId)
        {
            ImageBytes image =
                await imageService.LoadPerformanceMainImageBytesAsync(performanceId);
            if (image != null && image.Image != null)
            {
                return File(image.Image, image.ImageFormat);
            }

            return NotFound();
        }

        #endregion

    }
}