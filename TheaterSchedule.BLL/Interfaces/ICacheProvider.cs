using System;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface ICacheProvider
    {
        T GetAndSave<T>(Func<string> keyGetter, Func<T> objGet);
    }
}
