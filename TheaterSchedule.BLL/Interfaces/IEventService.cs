using System.Collections.Generic;
using TheaterSchedule.BLL.DTO;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IEventService
    {
        IEnumerable<EventDTO> LoadAvailable(string languageCode);
    }
}
