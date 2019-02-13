using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
using System.Linq;

namespace TheaterSchedule.DAL.Repositories
{
    public class PromoActionRepository : IPromoActionRepository
    {
        private TheaterDatabaseContext db;

        public PromoActionRepository(TheaterDatabaseContext context)
        {
            this.db = context;
        }

        public IEnumerable<PromoActionDataModel> GetAllCurrentPromoActions(string languageCode)
        {
            IEnumerable<PromoActionDataModel> listPromoActions = null;

            listPromoActions = from promoAction in db.PromoAction
                join promoActionTr in db.PromoActionTr on promoAction.PromoActionId equals promoActionTr.PromoActionId
                join language in db.Language on promoActionTr.LanguageId equals language.LanguageId
                where ((languageCode == language.LanguageCode) && (promoAction.StartDate <= DateTime.Now) && (promoAction.EndDate >= DateTime.Now))
                select new PromoActionDataModel
                {
                    PromoActionName = promoActionTr.PromoActionName,
                    Description = promoActionTr.Description,
                    StartDate = promoAction.StartDate,
                    EndDate = promoAction.EndDate,
                };

            return listPromoActions;
        }
    }
}
