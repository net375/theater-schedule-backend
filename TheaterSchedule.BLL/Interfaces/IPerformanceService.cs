﻿using TheaterSchedule.BLL.DTO;
using System.Collections.Generic;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IPerformanceService
    {
        IEnumerable<PerformanceDTO> LoadPerformance( int id );
    }
}
