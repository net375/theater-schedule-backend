using AutoMapper;
using Entities.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
using TheaterSchedule.BLL;

namespace TheaterSchedule.BLL.Services
{
    public class WishlistService : IWishlistService
    {
        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private IWishlistRepository WishlistRepository;
        private IAccountRepository accountRepository;
        private IMemoryCache memoryCache;
        private IPerfomanceRepository perfomanceRepository;

        public WishlistService(
            ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork,
            IWishlistRepository WishlistRepository,
            IAccountRepository accountRepository,
            IMemoryCache memoryCache,
            IPerfomanceRepository perfomanceRepository)
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.WishlistRepository = WishlistRepository;
            this.accountRepository = accountRepository;
            this.memoryCache = memoryCache;
            this.perfomanceRepository = perfomanceRepository;
        }

        public IEnumerable<WishlistDTO> LoadWishlist(
            string phoneId, string languageCode)
        {
            List<PerformanceDataModel> performancesWp = null;

            string memoryCacheKey = Constants.PerformancesCacheKey + languageCode;

            if (!memoryCache.TryGetValue(memoryCacheKey, out performancesWp))
            {
                performancesWp =
                    perfomanceRepository.GetPerformanceTitlesAndImages(languageCode);

                memoryCache.Set(memoryCacheKey, performancesWp);
            }

            return new MapperConfiguration(
                    cfg => cfg.CreateMap<WishlistDataModel, WishlistDTO>())
                .CreateMapper()
                .Map<IEnumerable<WishlistDataModel>, IEnumerable<WishlistDTO>>(
                    WishlistRepository.GetWishlistByPhoneIdentifier(
                        phoneId, languageCode, performancesWp));
        }

        public void SaveOrDeletePerformance(string phoneId, int performanceId)
        {
            Wishlist performance =
                WishlistRepository.GetPerformanceByPhoneIdAndPerformanceId(
                    phoneId, performanceId);

            if (performance == null)
            {
                int accountId = accountRepository.GetAccountByPhoneId(phoneId).AccountId;
                performance = new Wishlist()
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
