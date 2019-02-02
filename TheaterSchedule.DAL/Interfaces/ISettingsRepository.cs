using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.DAL.Entities;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface ISettingsRepository : IRepository<Settings>
    {
        Settings GetSettingsByPhoneId(string SettingsId);
        void CreateNewAccountAndSettingsWithCurrentPhoneId(Settings settings);
        void ChangeSettingsWithCurrentPhoneId(string SettingsId, Settings settings);
    }
}
