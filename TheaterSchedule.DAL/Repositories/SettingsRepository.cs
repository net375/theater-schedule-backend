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
        public Settings GetSettingsByPhoneId(string phoneId)
        {
           Settings settings = null;
           settings  = db.Settings.Select(a => a).Where(a => a.Account.PhoneIdentifier== phoneId).SingleOrDefault();
           return settings;
        }

        //Put
        public void ChangeSettingsWithCurrentPhoneIdOrCreateNew(string phoneId, Settings settings)
        {
            Settings ResultSettings = null;
            if (db.Settings.Any(s => s.Account.PhoneIdentifier == phoneId))
            {            
                ResultSettings = db.Settings.Select(a => a).Where(a => a.Account.PhoneIdentifier == phoneId).SingleOrDefault();
                ResultSettings.LanguageId = settings.LanguageId;
            }
            else
            {
                //Post
                db.Settings.Add(settings);
                db.Account.Add(new Account { PhoneIdentifier = phoneId, SettingsId = settings.SettingsId });                            
            }        
           
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
