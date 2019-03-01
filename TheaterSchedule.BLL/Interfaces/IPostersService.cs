using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheaterSchedule.BLL.DTO;
namespace TheaterSchedule.BLL.Interfaces
{
    public interface IPostersService
    {
        Task<List<PostersDTO>> LoadPostersData(string languageCode);
    }
}
