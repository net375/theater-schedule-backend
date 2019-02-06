using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using Entities.Models;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.BLL.Services
{
    public class PostersService : IPostersService
    {
        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private IPerfomanceRepository perfomanceRepository;
        private IImageService imageService;

        public PostersService(ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork, IPerfomanceRepository perfomanceRepository, IImageService imageService)
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.perfomanceRepository = perfomanceRepository;
            this.imageService = imageService;
        }

        public List<PostersDTO> LoadPostersData(string languageCode)
        {
            List<PostersDTO> postersRequest = new List<PostersDTO>();
            List<PerformanceDataModel> selectedPerformances = perfomanceRepository.GetPerformanceTitlesAndImages(languageCode);

            foreach (var performance in selectedPerformances)
            {
                postersRequest.Add(new PostersDTO()
                {
                    MainImage = imageService.ImageToBase64(performance.MainImage),
                    Title = performance.Title
                });
            }
            return postersRequest;
        }
    }
}
