using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterSchedule.DAL.Interfaces
{
    interface ISettingsUnitOfWork:IDisposable
    {
        ISettingsRepository Settings { get; }
        void Save();
    }
}
