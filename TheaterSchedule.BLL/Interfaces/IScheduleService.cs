using System;
using System.Collections.Generic;
using TheaterSchedule.BLL.DTO;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IScheduleService
    {
        IEnumerable<ScheduleDTO> FilterByDate(
            string phoneId, string languageCode, 
            DateTime? startDate, DateTime? endDate);
    }
}
