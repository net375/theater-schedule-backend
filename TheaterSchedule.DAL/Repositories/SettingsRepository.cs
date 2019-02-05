using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Entities.Models;
using TheaterSchedule.DAL.Interfaces;

namespace TheaterSchedule.DAL.Repositories
{
    public class SettingsRepository : ISettingsRepository
    {

        private TheaterDatabaseContext db;

        public SettingsRepository(TheaterDatabaseContext context)
        {
            this.db = context;
        }

        public void Add(Settings settings)
        {
            db.Settings.Add(settings);
        }

        public Settings GetSettingsByPhoneId(string phoneId)
        {
            return db.Settings.Include(s => s.Language).SingleOrDefault(a => a.Account.PhoneIdentifier == phoneId);       
        }

    }
}
