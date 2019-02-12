using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
            ImageBase64DTO imageDTO = await imageService.LoadPerformanceMainImageBase64Async(performanceId);
            if (imageDTO != null)
                return imageDTO;

            return NotFound();
        }

        [Produces("application/json")]
        [HttpGet("GetGalleryImages")]
        public async Task<ActionResult<List<ImageBase64DTO>>> GetGalleryImages(int performanceId)
        {
            return await imageService.LoadPerformanceGalleryBase64Async(performanceId);
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