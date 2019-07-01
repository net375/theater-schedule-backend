using System;
using Microsoft.Extensions.Caching.Memory;
using TheaterSchedule.BLL.Interfaces;

namespace TheaterSchedule.BLL.Services
{
    public class ImageService : IImageService
    {
        private IMemoryCache cache;

        public ImageService(IMemoryCache memoryCache)
        {
            cache = memoryCache;
        }

        public string ImageToBase64(byte[] image)
        {
            string base64Image = Convert.ToBase64String(image);
            return base64Image;
        }
    }
}
