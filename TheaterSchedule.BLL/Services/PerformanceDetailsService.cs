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
        private IPerformanceDetailsService performanceDetailsService;
        // вони мають бути організовані за однією логіку тому повинні використовувати один інтерфейс
        // в цьому сервісі цього не треба робити
        // Просто використовувати 
        public PerformanceDetailsService(ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork,
            IPerformanceDetailsService performanceDetailsService)
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.performanceDetailsService = performanceDetailsService;
        }

        public PerformanceDetailsDTOBase LoadPerformanceDetails(string phoneId, string languageCode, int id)
        {
            return performanceDetailsService.LoadPerformanceDetails(phoneId, languageCode, id);
        }
    }
}
