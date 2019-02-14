using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IPromoActionRepository
    {
        IEnumerable<PromoActionDataModel> GetAllCurrentPromoActions(string languageCode);
    }
}
