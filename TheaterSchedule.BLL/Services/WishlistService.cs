using AutoMapper;
using Entities.Models;
using System.Collections.Generic;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
using WishlistDTO = TheaterSchedule.BLL.DTO.WishlistDTO;

namespace TheaterSchedule.BLL.Services
{
    public class WishlistService : IWishlistService
    {
        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private IWishlistRepository WishlistRepository;
        private IAccountRepository accountRepository;

        public WishlistService(
            ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork,
            IWishlistRepository WishlistRepository,
            IAccountRepository accountRepository)
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.WishlistRepository = WishlistRepository;
            this.accountRepository = accountRepository;
        }

        public IEnumerable<WishlistDTO> LoadWishlist(
            string phoneId, string languageCode)
        {
            return new MapperConfiguration(
                    cfg => cfg.CreateMap<WishlistDataModel, WishlistDTO>())
                .CreateMapper()
                .Map<IEnumerable<WishlistDataModel>, IEnumerable<WishlistDTO>>(
                    WishlistRepository.GetWishlistByPhoneIdentifier(
                        phoneId, languageCode));
        }

        public void SaveOrDeletePerformance(string phoneId, int performanceId)
        {
            Entities.Models.Wishlist performance =
                WishlistRepository.GetPerformanceByPhoneIdAndPerformanceId(
                    phoneId, performanceId);

            if (performance == null)
            {
                int accountId = accountRepository.GetAccountByPhoneId(phoneId).AccountId;
                performance = new Entities.Models.Wishlist()
                {
                    AccountId = accountId,
                    PerformanceId = performanceId
                };
                WishlistRepository.Add(performance);
            }
            else
            {
                WishlistRepository.Remove(performance);
            }

            theaterScheduleUnitOfWork.Save();
        }
    }
}
