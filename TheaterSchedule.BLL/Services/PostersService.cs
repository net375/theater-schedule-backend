using System.Collections.Generic;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
using Microsoft.Extensions.Caching.Memory;

namespace TheaterSchedule.BLL.Services
{
    public class PostersService : IPostersService
    {
        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private IPerfomanceRepository perfomanceRepository;
        private IImageService imageService;
        private IMemoryCache memoryCache;

        public PostersService(
            ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork, 
            IPerfomanceRepository perfomanceRepository, 
            IImageService imageService, 
            IMemoryCache memoryCache)
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.perfomanceRepository = perfomanceRepository;
            this.imageService = imageService;
            this.memoryCache = memoryCache;
        }

        public List<Posters> LoadPostersData(string languageCode)
        {
            List<Posters> postersRequest = null;

            string memoryCacheKey = languageCode;        
            if (!memoryCache.TryGetValue(memoryCacheKey, out postersRequest))
            {
                postersRequest = new List<Posters>();
                List<PerformanceDataModel> selectedPerformances = 
                    perfomanceRepository.GetPerformanceTitlesAndImages(languageCode);
                foreach (var performance in selectedPerformances)
                {               
                    postersRequest.Add(new Posters()
                    {
                        MainImage = 
                            performance.MainImageUrl == null 
                                ? imageService.ImageToBase64(performance.MainImage) 
                                : performance.MainImageUrl,
                        Title = performance.Title,
                        PerformanceId = performance.PerformanceId
                    });
                }             
                memoryCache.Set(memoryCacheKey, postersRequest);
            }

            return postersRequest;
        }
    }
}
