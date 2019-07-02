using System;
using System.Threading.Tasks;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface ITheaterScheduleUnitOfWork : IDisposable
    {
        void Save();
        Task SaveAsync();
    }
}
