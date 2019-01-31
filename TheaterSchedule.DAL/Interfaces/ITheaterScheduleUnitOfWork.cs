using System;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface ITheaterScheduleUnitOfWork : IDisposable
    {
        IScheduleRepository Schedule { get; }
        void Save();
    }
}
