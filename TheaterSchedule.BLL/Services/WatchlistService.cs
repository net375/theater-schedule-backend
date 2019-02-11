using AutoMapper;
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

        public WatchlistService(
            ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork,
            IWatchlistRepository watchlistRepository )
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.watchlistRepository = watchlistRepository;
        }

        public IEnumerable<WatchlistDTO> GetWatchlist(
            string phoneId, string languageCode)
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


            watchlistRepository.SaveOrDeletePerformance(phoneId, scheduleId);
        }
    }
}
