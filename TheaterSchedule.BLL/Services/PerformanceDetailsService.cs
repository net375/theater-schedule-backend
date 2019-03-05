using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
using AutoMapper;

namespace TheaterSchedule.BLL.Services
{
    public class PerformanceDetailsService : IPerformanceDetailsService
    {
        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private IPerformanceDetailsRepository performanceDetailsRepository;
        // вони мають бути організовані за однією логіку тому повинні використовувати один інтерфейс
        // в цьому сервісі цього не треба робити
        // Просто використовувати 
        public PerformanceDetailsService(ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork,
            IPerformanceDetailsRepository performanceDetailsRepository)
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.performanceDetailsRepository = performanceDetailsRepository;
        }

        public PerformanceDetailsDTO LoadPerformanceDetails(string phoneId, string languageCode, int id)
        {
            // Викликає потрібний нам сервіс
            // тут треба якийсь іф
            var mapper =
                new MapperConfiguration(cfg => cfg.CreateMap<PerformanceDetailsDataModel, PerformanceDetailsDTO>())
                    .CreateMapper();
            return mapper.Map<PerformanceDetailsDataModelBase, PerformanceDetailsDTO>(
                performanceDetailsRepository.GetInformationAboutPerformance(phoneId, languageCode, id));
        }
    }
}
