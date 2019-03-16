using Entities.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface ISettingsRepository
    {
        void Add(Settings settings);
        Settings GetSettingsByPhoneId(string SettingsId);
    }
}
