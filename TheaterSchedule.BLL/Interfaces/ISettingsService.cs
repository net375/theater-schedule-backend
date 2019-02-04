using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.BLL.DTO;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface ISettingsService
    {
        void StoreSettings(string phoneId, SettingsDTO settingsRequest);
        SettingsDTO LoadSettings(string phoneId);
    }
}
