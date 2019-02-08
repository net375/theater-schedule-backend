using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.BLL.Interfaces;
namespace TheaterSchedule.BLL.Services
{
   public class ImageService: IImageService
    {
        public string ImageToBase64(byte[] image)
        {
            string base64Image = Convert.ToBase64String(image);
            return base64Image;
        }
    }

}
