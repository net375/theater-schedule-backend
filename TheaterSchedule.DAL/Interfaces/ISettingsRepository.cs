using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface ISettingsRepository
    {
        void Add(Settings settings);
        Settings GetSettingsByPhoneId(string SettingsId);
    }
}
