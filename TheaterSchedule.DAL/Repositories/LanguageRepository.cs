using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheaterSchedule.DAL.Interfaces;
using Entities.Models;

namespace TheaterSchedule.DAL.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {

        private TheaterDatabaseContext db;

        public LanguageRepository(TheaterDatabaseContext context)
        {
            this.db = context;
        }

        public Language GetLanguageById(int id)
        {
            return db.Language.SingleOrDefault(l => l.LanguageId == id);
        }

        public Language GetLanguageByName(string languageName)
        {
            return db.Language.SingleOrDefault(l => l.LanguageName == languageName);
        }


    }
}
