using System;
using TheaterSchedule.DAL.Entities;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface ITheaterScheduleUnitOfWork : IDisposable
    {
        IRepository<Schedule> Schedule { get; }
        IRepository<Performance> Performances { get; }
        void Save();
    }
}
