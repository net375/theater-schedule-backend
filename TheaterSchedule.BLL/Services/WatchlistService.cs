using AutoMapper;
using Entities.Models;
using System.Collections.Generic;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.BLL.Services
{
    public class WatchlistService : IWatchlistService
    {
        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private IWatchlistRepository watchlistRepository;
        private IAccountRepository accountRepository;

        public WatchlistService(
            ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork,
            IWatchlistRepository watchlistRepository,
            IAccountRepository accountRepository )
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.watchlistRepository = watchlistRepository;
            this.accountRepository = accountRepository;
        }

        public IEnumerable<WatchlistDTO> LoadWatchlist(
            string phoneId, string languageCode )
        {
            return new MapperConfiguration(
                    cfg => cfg.CreateMap<WatchlistDataModel, WatchlistDTO>() )
                .CreateMapper()
                .Map<IEnumerable<WatchlistDataModel>, IEnumerable<WatchlistDTO>>(
                    watchlistRepository.GetWatchlistByPhoneIdentifier(
                        phoneId, languageCode ) );
        }

        public void SaveOrDeletePerformance( string phoneId, int scheduleId )
        {
            Watchlist performance =
                watchlistRepository.GetPerformanceByPhoneIdAndScheduleId(
                    phoneId, scheduleId );

            if ( performance == null )
            {
                int accountId = accountRepository.GetAccountByPhoneId( phoneId ).AccountId;
                performance = new Watchlist()
                {
                    AccountId = accountId,
                    ScheduleId = scheduleId
                };
                watchlistRepository.Add( performance );
            }
            else
            {
                watchlistRepository.Remove( performance );
            }

            theaterScheduleUnitOfWork.Save();
        }
    }
}
