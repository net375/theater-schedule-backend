using System.Collections.Generic;
using TheaterSchedule.BLL.DTO;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IEventService
    {
        IEnumerable<Event> LoadAvailable(string languageCode);
    }
}
