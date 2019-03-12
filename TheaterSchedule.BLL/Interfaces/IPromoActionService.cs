using System.Collections.Generic;
using TheaterSchedule.BLL.DTO;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IPromoActionService
    {
        IEnumerable<PromoActionDTO> LoadAvailable(string languageCode);
    }
}
