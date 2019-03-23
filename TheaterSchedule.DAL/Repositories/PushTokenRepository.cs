using System;
using System.Collections.Generic;
using TheaterSchedule.DAL.Interfaces;
using Entities.Models;
using System.Linq;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Repositories
{
    public class PushTokenRepository : IPushTokenRepository
    {
        private TheaterDatabaseContext db;

        public PushTokenRepository(TheaterDatabaseContext context)
        {
            db = context;
        }

        public void Add(PushToken pushToken)
        {
            db.PushToken.Add(pushToken);
        }

        public IEnumerable<PushTokenDataModel> GetAllPushTokensToSendNotifications(IEnumerable<PerformanceDataModel> performancesWp,
            IEnumerable<ScheduleDataModelBase> scheduleWp)
        {
            var tokenWithLanguage = (from token in db.PushToken
                            join account in db.Account on token.AccountId equals account.AccountId
                            join settings in db.Settings on account.SettingsId equals settings.SettingsId
                            join language in db.Language on settings.LanguageId equals language.LanguageId
                            join frequency in db.NotificationFrequency on settings.NotificationFrequencyId equals frequency.NotificationFrequencyId
                            join wishlist in db.Wishlist on account.AccountId equals wishlist.AccountId

                            join performance in performancesWp on wishlist.PerformanceId equals performance.PerformanceId
                            join schedule in scheduleWp on performance.PerformanceId equals schedule.PerformanceId

                            where (schedule.Beginning.Day == (DateTime.Today.AddDays(frequency.Frequency).Day) 
                                    && (schedule.PerformanceId == wishlist.PerformanceId))

                            select new PushTokenDataModel
                            {
                                Token =  token.Token,
                                LanguageCode = language.LanguageCode
                            }).Distinct().ToList();

            return tokenWithLanguage;
        }
    }
}
