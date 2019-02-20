using System.Collections.Generic;
using System.Threading.Tasks;
using TheaterSchedule.BLL.DTO;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IImageService
    {
        string GeMimeTypeFromImageByteArray(byte[] byteArray);
        string ImageToBase64(byte[] image);
        Task<byte[]> TryAddPerformanceImageToCacheAsync(int id);
        Task<IEnumerable<byte[]>> TryAddGalleryImagesToCacheAsync(int performanceId);
        Task<ImageBytesDTO> LoadPerformanceMainImageBytesAsync(int id);
        Task<List<ImageBytesDTO>> LoadPerformanceGalleryBytesAsync(int id);
    }
}
