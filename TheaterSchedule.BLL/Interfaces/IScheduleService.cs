using System;
using System.Collections.Generic;
using TheaterSchedule.BLL.DTO;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IScheduleService
    {
        IEnumerable<ScheduleBaseDTO> FilterByDate(
            string languageCode, 
            DateTime? startDate);
    }
}
