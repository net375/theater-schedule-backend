using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IEventRepository
    {
        IEnumerable<EventDataModel> GetAllEvents(string languageCode);
    }
}
