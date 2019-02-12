using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IImageRepository
    {
        Task<byte[]> GetPerformanceImageAsync(int id);
        Task<IEnumerable<byte[]>> GetGalleryImagesAsync(int id);
    }
}
