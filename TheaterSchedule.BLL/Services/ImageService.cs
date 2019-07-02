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
        private IMemoryCache cache;

        public ImageService(
            IMemoryCache memoryCache)
        {
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
                        return ImageCodecInfo.GetImageEncoders()
                            .First(codec => codec.FormatID == image.RawFormat.Guid).MimeType;
                    }
                }
            }
            catch (ArgumentException)
            {
                return "text/plain";
            }
        }   
    }
}
