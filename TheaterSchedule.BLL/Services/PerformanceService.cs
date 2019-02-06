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

using PerformanceDTO = TheaterSchedule.BLL.DTO.PerformanceDTO;

namespace TheaterSchedule.BLL.Services
{
    public class PerformanceService : IPerformanceService
    {
        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private IPerformanceRepository performanceRepository;

        public PerformanceService( ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork,
            IPerformanceRepository performanceRepository )
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.performanceRepository = performanceRepository;
        }
        public IEnumerable<PerformanceDTO> LoadPerformance( string languageCode, int id )
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PerformanceDataModel, PerformanceDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<PerformanceDataModel>, List<PerformanceDTO>>(performanceRepository.GetInformationAboutPerformanceScreen(languageCode, id));

        }
    }
}
