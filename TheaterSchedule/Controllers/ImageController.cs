using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;


namespace TheaterSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        IImageService imageService;

        public ImageController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        [Produces("application/json")]
        [ProducesResponseType(404)]
        [HttpGet]
        public async Task<ActionResult<ImageBase64DTO>> Get(int performanceId)
        {
            ImageBytesDTO imageDTO = await imageService.LoadPerformanceMainImageBytesAsync(performanceId);
            if (imageDTO != null)
            {
                ImageBase64DTO imageBase64DTO = new ImageBase64DTO()
                {
                    Image = imageService.ImageToBase64(imageDTO.Image),
                    ImageFormat = imageDTO.ImageFormat
                };

                return imageBase64DTO;
            }

            return NotFound();
        }

        [Produces("application/json")]
        [HttpGet("GetGalleryImages")]
        public async Task<ActionResult<List<ImageBase64DTO>>> GetGalleryImages(int performanceId)
        {
            List<ImageBase64DTO> result = new List<ImageBase64DTO>();
            List<ImageBytesDTO> images = await imageService.LoadPerformanceGalleryBytesAsync(performanceId);

            await Task.Run(() =>
            {
                result = images.Select(image => new ImageBase64DTO()
                {
                    Image = imageService.ImageToBase64(image.Image),
                    ImageFormat = image.ImageFormat
                }).ToList<ImageBase64DTO>();
            });

            return result;
        }

        [ProducesResponseType(404)]
        [HttpGet("GetAsFile")]
        public async Task<IActionResult> GetAsFile(int performanceId)
        {
            ImageBytesDTO imageDTO = await imageService.LoadPerformanceMainImageBytesAsync(performanceId);
            if (imageDTO != null && imageDTO.Image != null)
            {
                return File(imageDTO.Image, imageDTO.ImageFormat);
            }

            return NotFound();
        }

    }
}