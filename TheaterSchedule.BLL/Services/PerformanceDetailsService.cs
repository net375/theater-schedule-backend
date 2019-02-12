using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using Entities.Models;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Repositories;
using TheaterSchedule.DAL.Models;
using AutoMapper;

namespace TheaterSchedule.BLL.Services
{
    public class PerformanceDetailsService : IPerformanceDetailsService
    {
        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private IPerformanceDetailsRepository performanceDetailsRepository;

        public PerformanceDetailsService( ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork,
            IPerformanceDetailsRepository performanceDetailsRepository )
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.performanceDetailsRepository = performanceDetailsRepository;
        }
        public PerformanceDetailsDTO LoadPerformanceDetails( string languageCode, int id )
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PerformanceDetailsDataModel, PerformanceDetailsDTO>()).CreateMapper();
            return mapper.Map<PerformanceDetailsDataModel, PerformanceDetailsDTO>(performanceDetailsRepository.GetInformationAboutPerformanceScreen(languageCode, id));
           

        }
    }
}
