using System;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface ITheaterScheduleUnitOfWork : IDisposable
    {
        void Save();
    }
}
