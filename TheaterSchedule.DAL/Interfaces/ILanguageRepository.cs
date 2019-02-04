using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.DAL.Entities;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface ILanguageRepository
    {
        Language GetLanguageByName(string languageName);
        Language GetLanguageById(int languageId);
    }
}
