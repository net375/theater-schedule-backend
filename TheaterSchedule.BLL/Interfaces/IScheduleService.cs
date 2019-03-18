﻿using System;
using System.Collections.Generic;
using TheaterSchedule.BLL.DTO;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IScheduleService
    {
        IEnumerable<ScheduleDTOBase> FilterByDate(
            string languageCode, 
            DateTime? startDate, DateTime? endDate);
    }
}
