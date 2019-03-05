﻿using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Repositories;
using TheaterSchedule.DAL.Models;
using AutoMapper;

namespace TheaterSchedule.BLL.Services
{
    public class PerformanceDetailsServiceDb : IPerformanceDetailsService
    {
        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private PerformanceDetailsRepository performanceDetailsRepository;
  
        public PerformanceDetailsServiceDb( ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork,
            PerformanceDetailsRepository performanceDetailsRepository )
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.performanceDetailsRepository = performanceDetailsRepository;
        }

        public PerformanceDetailsDTO LoadPerformanceDetails( string phoneId, string languageCode, int id )
        {
        
            var mapper =
                new MapperConfiguration(cfg => cfg.CreateMap<PerformanceDetailsDataModel, PerformanceDetailsDTO>())
                    .CreateMapper();
            return mapper.Map<PerformanceDetailsDataModelBase, PerformanceDetailsDTO>(
                performanceDetailsRepository.GetInformationAboutPerformance(phoneId, languageCode, id));
        }
    }
}
