using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.BLL.DTO;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IEventService
    {
        IEnumerable<EventDTO> LoadAvailable(string languageCode);
    }
}
