using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.DAL.Interfaces;
using Entities.Models;
using System.Linq;
using System.Linq.Expressions;

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

        public IEnumerable<string> GetAllPushTokens()
        {
            var tokens = from t in db.PushToken
                         select t.Token;

            return tokens;
        }
    }
}
