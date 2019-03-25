using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
using AutoMapper;

namespace TheaterSchedule.BLL.Services
{
    public class PerformanceDetailsServiceDb : IPerformanceDetailsService
    {
        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private IPerformanceDetailsRepository performanceDetailsRepository;
  
        public PerformanceDetailsServiceDb( 
            ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork,
            IPerformanceDetailsRepository performanceDetailsRepository )
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.performanceDetailsRepository = performanceDetailsRepository;
        }

        public PerformanceDetailsBaseDTO LoadPerformanceDetails( 
            string phoneId, string languageCode, int id )
        {
            var mapper =
                new MapperConfiguration(cfg => 
                        cfg.CreateMap<PerformanceDetailsDataModel, PerformanceDetailsDTO>())
                    .CreateMapper();
            return mapper.Map<PerformanceDetailsDataModelBase, PerformanceDetailsDTO>(
                performanceDetailsRepository.GetInformationAboutPerformance( 
                    phoneId, languageCode, id ) ); 
        }
    }
}
