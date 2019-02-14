using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IGalleryImageRepository
    {
        byte[] GetGalleryImagebyPerformanceId(int id);
    }
}
