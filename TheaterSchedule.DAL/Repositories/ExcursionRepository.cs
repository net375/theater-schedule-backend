using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
using System.Linq;
using Entities.Models;

namespace TheaterSchedule.DAL.Repositories
{
    public class ExcursionRepository : IExcursionRepository
    {
        private TheaterDatabaseContext db;

        public ExcursionRepository(TheaterDatabaseContext context)
        {
            db = context;
        }


        public IEnumerable<ExcursionDataModel> GetAllExcursions(string languageCode)
        {
            IEnumerable<ExcursionDataModel> listExcursions = null;

            listExcursions = from excursion in db.Excursion
                             join excursionTr in db.ExcursionTr on excursion.ExcursionId equals excursionTr.ExcursionId
                             join language in db.Language on excursionTr.LanguageId equals language.LanguageId
                             where ((languageCode == language.LanguageCode) && (excursion.Date >= DateTime.Now))
                               select new ExcursionDataModel
                               {
                                   ExcursionName = excursionTr.ExcursionName,
                                   ShortDescription = excursionTr.ShortDescription,
                                   FullDescription = excursionTr.FullDescription,
                                   Image = excursion.Image,
                                   Date = excursion.Date
                               };

            return listExcursions;
        }
    }
}
