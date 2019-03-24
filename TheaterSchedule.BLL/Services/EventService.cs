using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using AutoMapper;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.BLL.Services
{
    public class EventService : IEventService
    {
        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private IEventRepository eventRepository;

        public EventService(ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork, IEventRepository eventRepository)
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.eventRepository = eventRepository;
        }

        public IEnumerable<Event> LoadAvailable(string languageCode)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EventDataModel, Event>()).CreateMapper();
            return mapper.Map<IEnumerable<EventDataModel>, List<Event>>(eventRepository.GetAllEvents(languageCode));
        }
    }
}
