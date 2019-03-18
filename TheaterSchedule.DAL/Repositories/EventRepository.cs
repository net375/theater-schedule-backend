using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
using System.Linq;
using Entities.Models;

namespace TheaterSchedule.DAL.Repositories
{
    public class EventRepository : IEventRepository
    {
        private TheaterDatabaseContext db;

        public EventRepository(TheaterDatabaseContext context)
        {
            db = context;
        }


        public IEnumerable<EventDataModel> GetAllEvents(string languageCode)
        {
            IEnumerable<EventDataModel> listEvents = null;

            listEvents = from @event in db.Event
                         join eventTr in db.EventTr on @event.EventId equals eventTr.EventId
                         join language in db.Language on eventTr.LanguageId equals language.LanguageId
                         where ((languageCode == language.LanguageCode) && (@event.Date >= DateTime.Now))
                           select new EventDataModel
                           {
                               EventId = @event.EventId,
                               Title = eventTr.Title,
                               ShortDescription = eventTr.ShortDescription,
                               FullDescription = eventTr.FullDescription,
                               Type = eventTr.Type,
                               Image = @event.Image,
                               Date = @event.Date
                           };

            return listEvents;
        }
    }
}
