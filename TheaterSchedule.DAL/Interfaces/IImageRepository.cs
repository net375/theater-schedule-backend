using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IImageRepository
    {
        Task<int> GetGalleryImagesCountAsync(int performanceId);
        Task<byte[]> GetPerformanceImageAsync(int id);
        Task<IEnumerable<byte[]>> GetGalleryImagesAsync(int id);
    }
}
