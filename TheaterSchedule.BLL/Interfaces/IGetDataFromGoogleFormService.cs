
using TheaterSchedule.BLL.Classes;
namespace TheaterSchedule.BLL.Interfaces
{
    public interface IGetDataFromGoogleFormService
    {
        Form GetDataFromServer(string url);
    }
}
