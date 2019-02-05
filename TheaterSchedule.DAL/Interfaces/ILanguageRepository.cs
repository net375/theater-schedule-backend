using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface ILanguageRepository
    {
        Language GetLanguageByName(string languageName);
        Language GetLanguageById(int languageId);
    }
}
