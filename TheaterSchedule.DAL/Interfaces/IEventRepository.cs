using System.Collections.Generic;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IEventRepository
    {
        IEnumerable<EventDataModel> GetAllEvents(string languageCode);
    }
}
