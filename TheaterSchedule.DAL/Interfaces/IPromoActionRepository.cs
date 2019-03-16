using System.Collections.Generic;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IPromoActionRepository
    {
        IEnumerable<PromoActionDataModel> GetAllCurrentPromoActions(string languageCode);
    }
}
