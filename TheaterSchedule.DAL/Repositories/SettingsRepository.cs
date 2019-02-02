using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TheaterSchedule.DAL.Contexts;
using TheaterSchedule.DAL.Entities;
using TheaterSchedule.DAL.Interfaces;

namespace TheaterSchedule.DAL.Repositories
{
    class SettingsRepository : ISettingsRepository
    {

        private TheaterScheduleContext db;

        public SettingsRepository(TheaterScheduleContext context)
        {
            this.db = context;
        }

        //Get
        public Settings GetSettingsByPhoneId(string SettingsId)
        {
            Settings settings = null;
            settings = db.Account.Select(a => a.AccountNavigation).Where(a => a.SettingsId == SettingsId).SingleOrDefault();
            return settings;
        }

        // Post
        public void CreateNewAccountWithCurrentPhoneId(Settings settings)
        {
            db.Settings.Add(settings);
            db.Account.Add(new Account { PhoneIdentifier = settings.SettingsId });
        }

        //Put
        public void ChangeAccountWithCurrentPhoneId(string SettingsId, Settings settings)
        {
            Settings ResultSettings = db.Settings.Where(s => s.SettingsId == SettingsId).SingleOrDefault();
            ResultSettings.Language = settings.Language;
        }

        public IEnumerable<Settings> GetWithInclude(params Expression<Func<Settings, object>>[] includeProperties)
        {
            IQueryable<Settings> query = db.Settings.AsNoTracking();
            IQueryable<Settings> scheduleList = includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return scheduleList;
        }

    }
}
