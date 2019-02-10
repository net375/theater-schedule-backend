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
            string languageCode, string phoneIdentifier )
        {
            return new MapperConfiguration(
                    cfg => cfg.CreateMap<WatchlistDataModel, WatchlistDTO>() )
                .CreateMapper()
                .Map<IEnumerable<WatchlistDataModel>, List<WatchlistDTO>>(
                    watchlistRepository.GetWatchlistByPhoneIdentifier(
                        languageCode, phoneIdentifier ) );
        }
    }
}
