using System.Collections.Generic;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IExcursionRepository
    {
        IEnumerable<ExcursionDataModel> GetAllExcursions(string languageCode);
    }
}
