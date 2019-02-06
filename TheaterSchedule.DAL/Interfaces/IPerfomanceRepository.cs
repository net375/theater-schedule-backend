using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using TheaterSchedule.DAL.Interfaces;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IPerfomanceRepository
    {
        IEnumerable<byte[]> GetAllPerformanceImages();
        List<Performance> GetPerformanceTitles(int settingsId);
    }
}
