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
           settings  = db.Settings.Select(a => a).Where(a => a.Account.PhoneIdentifier== SettingsId).SingleOrDefault();
           return settings;
        }

        // Post
        public void CreateNewAccountAndSettingsWithCurrentPhoneId(string phoneId, Settings settings)
        {     
            db.Settings.Add(settings);
            db.Account.Add(new Account { PhoneIdentifier = phoneId, SettingsId=settings.SettingsId });         
        }

        //Put
        public void ChangeSettingsWithCurrentPhoneId(string phoneId, Settings settings)
        {
            Settings ResultSettings = null;
            ResultSettings = db.Settings.Select(a => a).Where(a => a.Account.PhoneIdentifier == phoneId).SingleOrDefault();  
            ResultSettings.LanguageId = settings.LanguageId;
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
