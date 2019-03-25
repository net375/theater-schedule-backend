using AutoMapper;
using Entities.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
using TheaterSchedule.BLL;
using System;
using System.Linq;

namespace TheaterSchedule.BLL.Services
{
    public class CacheProvider
    {
        private IMemoryCache memoryCache;
        public CacheProvider(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        public T GetAndSave<T>(Func< string> keyGetter, Func<T> objGet) 
        {
            string memoryCacheKey = keyGetter();
            T result;
            if (!memoryCache.TryGetValue(memoryCacheKey, out result))
            {
                result = objGet();
                     
         
                memoryCache.Set(memoryCacheKey, result);
            }
            return result; 
        }
    }

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

        private string GetKey(string languageCode)
        {
            string memoryCacheKey = Constants.PerformancesCacheKey + languageCode;
            return memoryCacheKey;
        }

        public IEnumerable<WishlistDTO> LoadWishlist(string phoneId, string languageCode)
        {
            var cacheProvider = new CacheProvider(memoryCache);

            var performancesWp = cacheProvider.GetAndSave(
                () => GetKey(languageCode),
                () => perfomanceRepository.GetPerformanceTitlesAndImages(languageCode));

            /*List<PerformanceDataModel> performancesWp = null;

            string memoryCacheKey = Constants.PerformancesCacheKey + languageCode;

            if (!memoryCache.TryGetValue(memoryCacheKey, out performancesWp))
            {
                performancesWp =
                    perfomanceRepository.GetPerformanceTitlesAndImages(languageCode);

                memoryCache.Set(memoryCacheKey, performancesWp);
            }*/

            var perfIds = WishlistRepository.GetPerformanceIdsInWishlist(phoneId, languageCode);

            var result = from perfId in perfIds
                         join perfWp in performancesWp 
                            on perfId equals perfWp.PerformanceId
                         select new WishlistDTO
                         {
                             PerformanceId = perfId,
                             MainImage = perfWp.MainImageUrl,
                             Title = perfWp.Title
                         };

            return result;

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
