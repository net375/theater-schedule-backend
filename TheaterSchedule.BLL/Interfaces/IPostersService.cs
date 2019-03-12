using System.Collections.Generic;
using TheaterSchedule.BLL.DTO;
namespace TheaterSchedule.BLL.Interfaces
{
    public interface IPostersService
    {
        List<PostersDTO> LoadPostersData(string languageCode);
    }
}
