using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using AutoMapper;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
using System.Collections.Generic;

namespace TheaterSchedule.BLL.Services
{
    public class PromoActionService : IPromoActionService
    {
        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private IPromoActionRepository promoActionRepository;

        public PromoActionService(
            ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork, 
            IPromoActionRepository promoActionRepository)
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.promoActionRepository = promoActionRepository;
        }

        public IEnumerable<PromoActionDTO> LoadAvailable(string languageCode)
        {
            var mapper = new MapperConfiguration(cfg => 
                cfg.CreateMap<PromoActionDataModel, PromoActionDTO>())
                .CreateMapper();
            return mapper.Map<IEnumerable<PromoActionDataModel>, List<PromoActionDTO>>(
                promoActionRepository.GetAllCurrentPromoActions(languageCode));
        }
    }
}
