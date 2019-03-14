using System.Collections.Generic;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using AutoMapper;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.BLL.Services
{
    public class ExcursionService : IExcursionService
    {
        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private IExcursionRepository excursionRepository;

        public ExcursionService(
            ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork, 
            IExcursionRepository excursionRepository)
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.excursionRepository = excursionRepository;
        }

        public IEnumerable<ExcursionDTO> LoadAvailable(string languageCode)
        {
            var mapper = new MapperConfiguration(cfg => 
                cfg.CreateMap<ExcursionDataModel, ExcursionDTO>())
                .CreateMapper();
            return mapper.Map<IEnumerable<ExcursionDataModel>, List<ExcursionDTO>>(
                excursionRepository.GetAllExcursions(languageCode));
        }
    }
}
