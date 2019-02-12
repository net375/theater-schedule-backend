using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IImageService
    {
        string ImageToBase64(byte[] image);
    }
}
