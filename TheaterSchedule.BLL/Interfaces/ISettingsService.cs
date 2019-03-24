using TheaterSchedule.BLL.DTO;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface ISettingsService
    {
        void StoreSettings(string phoneId, Settings settingsRequest);
        Settings LoadSettings(string phoneId);
    }
}
