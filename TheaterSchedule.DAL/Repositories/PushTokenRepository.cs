using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.DAL.Interfaces;
using Entities.Models;
using System.Linq;
using System.Linq.Expressions;
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

        public IEnumerable<PushTokenDataModel> GetAllPushTokensToSendNotifications()
        {
            var tokenWithLanguage = (from token in db.PushToken
                            join account in db.Account on token.AccountId equals account.AccountId
                            join settings in db.Settings on account.SettingsId equals settings.SettingsId
                            join language in db.Language on settings.LanguageId equals language.LanguageId
                            join wishlist in db.Wishlist on account.AccountId equals wishlist.AccountId
                            join performance in db.Performance on wishlist.PerformanceId equals performance.PerformanceId
                            join schedule in db.Schedule on performance.PerformanceId equals schedule.PerformanceId
                            where (schedule.Beginning.Day == (DateTime.Today.Day + 7) //notify in a week
                                    && (schedule.PerformanceId == wishlist.PerformanceId))

                            select new PushTokenDataModel
                            {
                                Token =  token.Token,
                                LanguageCode = language.LanguageCode
                            }).ToList();

            return tokenWithLanguage;
        }
    }
}
