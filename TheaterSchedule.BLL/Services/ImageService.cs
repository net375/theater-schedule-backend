using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.Extensions.Caching.Memory;
using Entities.Models;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.BLL.DTO;

namespace TheaterSchedule.BLL.Services
{
    public class ImageService : IImageService
    {
        private IImageRepository imageRepository;
        private IMemoryCache cache;

        private readonly int cacheExpirationMinutes = 20;

        public ImageService(IImageRepository imgRepository, IMemoryCache memoryCache)
        {
            imageRepository = imgRepository;
            cache = memoryCache;
        }

        public string ImageToBase64(byte[] image)
        {
            string base64Image = Convert.ToBase64String(image);
            return base64Image;
        }

        public string GeMimeTypeFromImageByteArray(byte[] byteArray)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream(byteArray))
                {
                    using (Image image = Image.FromStream(stream))
                    {
                        return ImageCodecInfo.GetImageEncoders().First(codec => codec.FormatID == image.RawFormat.Guid).MimeType;
                    }
                }
            }
            catch (ArgumentException)
            {
                return "text/plain";
            }
        }   

        public async Task<ImageBytesDTO> LoadPerformanceMainImageBytesAsync(int id)
        {
            ImageBytesDTO imageDTO = null;
            byte[] image = await TryAddPerformanceImageToCacheAsync(id);

            if (image != null)
            {
                await Task.Run(() =>
                {
                    imageDTO = new ImageBytesDTO()
                    {
                        Image = image,
                        ImageFormat = GeMimeTypeFromImageByteArray(image)
                    };
                });
            }

            return imageDTO;
        }

        public async Task<List<ImageBytesDTO>> LoadPerformanceGalleryBytesAsync(int id)
        {
            List<ImageBytesDTO> imagesDTO = new List<ImageBytesDTO>();
            IEnumerable<byte[]> images = await TryAddGalleryImagesToCacheAsync(id);

            await Task.Run(() =>
            {
                imagesDTO = images.Select(image => new ImageBytesDTO()
                {
                    Image = image,
                    ImageFormat = GeMimeTypeFromImageByteArray(image)
                }).ToList<ImageBytesDTO>();               
            });

            return imagesDTO;
        }

        public async Task<IEnumerable<byte[]>> TryAddGalleryImagesToCacheAsync(int performanceId)
        {
            IEnumerable<byte[]> images = new List<byte[]>();        
            string key = typeof(Performance).Name + typeof(ImageService).Name + typeof(GalleryImage).Name + performanceId.ToString();

            if (!cache.TryGetValue(key, out images))
            {
                images = await imageRepository.GetGalleryImagesAsync(performanceId);
                if (images.Count() > 0)
                {
                    cache.Set(key, images, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(cacheExpirationMinutes)));
                }
            }

            return images;
        }

        public async Task<byte[]> TryAddPerformanceImageToCacheAsync(int id)
        {
            byte[] image = null;
            string key = typeof(Performance).Name + typeof(ImageService).Name + id.ToString();

            if (!cache.TryGetValue(key, out image))
            {
                image = await imageRepository.GetPerformanceImageAsync(id);
                if (image != null)
                {
                    cache.Set(key, image, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(cacheExpirationMinutes)));
                }
            }

            return image;
        }

    }
}
