﻿using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.DAL.Entities;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface ISettingsRepository : IRepository<Settings>
    {
        Settings GetSettingsByPhoneId(string SettingsId);
        void CreateNewAccountWithCurrentPhoneId(Settings settings);
        void ChangeAccountWithCurrentPhoneId(string SettingsId, Settings settings);
    }
}