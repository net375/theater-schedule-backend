using System.Collections.Generic;
using System.Threading.Tasks;
using TheaterSchedule.BLL.DTO;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IImageService
    {
        string ImageToBase64(byte[] image);
    }
}
