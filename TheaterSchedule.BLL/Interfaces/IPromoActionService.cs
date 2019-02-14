using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.BLL.DTO;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IPromoActionService
    {
        IEnumerable<PromoActionDTO> LoadAvailable(string languageCode);
    }
}
