using Entities.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface ILanguageRepository
    {
        Language GetLanguageByName(string languageName);
        Language GetLanguageById(int languageId);
    }
}
