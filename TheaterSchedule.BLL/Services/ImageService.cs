using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Reflection;
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

        private int cacheExpirationMinutes = 20;

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

        public async Task<ImageBase64DTO> LoadPerformanceMainImageBase64Async(int id)
        {
            ImageBase64DTO imageDTO = null;
            byte[] image = await TryAddPerformanceImageToCacheAsync(id);

            if (image != null)
            {
                await Task.Run(() =>
                {
                    imageDTO = new ImageBase64DTO()
                    {
                        Image = ImageToBase64(image),
                        ImageFormat = GeMimeTypeFromImageByteArray(image)
                    };
                });
            }

            return imageDTO;
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

        public async Task<List<ImageBase64DTO>> LoadPerformanceGalleryBase64Async(int id)
        {
            List<ImageBase64DTO> imagesDTO = new List<ImageBase64DTO>();
            IEnumerable<byte[]> images = await TryAddGalleryImagesToCacheAsync(id);

            await Task.Run(() =>
            {
                foreach (var image in images)
                {
                    imagesDTO.Add(new ImageBase64DTO()
                    {
                        Image = ImageToBase64(image),
                        ImageFormat = GeMimeTypeFromImageByteArray(image)
                    });
                }
            });

            return imagesDTO;
        }

        public async Task<List<ImageBytesDTO>> LoadPerformanceGalleryBytesAsync(int id)
        {
            List<ImageBytesDTO> imagesDTO = new List<ImageBytesDTO>();
            IEnumerable<byte[]> images = await TryAddGalleryImagesToCacheAsync(id);

            await Task.Run(() =>
            {
                foreach (var image in images)
                {
                    imagesDTO.Add(new ImageBytesDTO()
                    {
                        Image = image,
                        ImageFormat = GeMimeTypeFromImageByteArray(image)
                    });
                }
            });

            return imagesDTO;
        }


        public async Task<IEnumerable<byte[]>> TryAddGalleryImagesToCacheAsync(int performanceId)
        {
            bool needUpdateCache = false;
            IEnumerable<byte[]> images = new List<byte[]>();
            int imgsNumber = await imageRepository.GetGalleryImagesCountAsync(performanceId);

            for (int nImg = 0; nImg < imgsNumber; nImg++)
            {
                byte[] image = null;
                string key = typeof(Performance).Name + performanceId.ToString() + typeof(GalleryImage).Name + nImg;

                if (!cache.TryGetValue(key, out image))
                {
                    images = await imageRepository.GetGalleryImagesAsync(performanceId);
                    needUpdateCache = true;
                    break;
                }
                else
                    images.Append(image);
            }

            if (needUpdateCache)
            {
                int nImg = 0;
                foreach (var image in images)
                {
                    string key = typeof(Performance).Name + performanceId.ToString() + typeof(GalleryImage).Name + nImg++;
                    cache.Set(key, image, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(cacheExpirationMinutes)));
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
