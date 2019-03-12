using System.Collections.Generic;
using TheaterSchedule.BLL.DTO;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IExcursionService
    {
        IEnumerable<ExcursionDTO> LoadAvailable(string languageCode);
    }
}
