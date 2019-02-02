using System;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface ITheaterScheduleUnitOfWork : IDisposable
    {
        IScheduleRepository Schedule { get; }
        IPerformanceRepository Performances { get; }
        IGalleryImageRepository GalleryImages { get; }
        void Save();
    }
}
