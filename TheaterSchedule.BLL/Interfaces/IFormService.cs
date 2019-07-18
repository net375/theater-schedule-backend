using System.Threading.Tasks;
using TheaterSchedule.BLL.DTOs;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IFormService
    {
        UrlDTO Add(UrlDTO link);

        UrlDTO GetUrl();
    }
}
