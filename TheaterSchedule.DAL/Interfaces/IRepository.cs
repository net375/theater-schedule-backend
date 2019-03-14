using WordPressPCL;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IRepository
    {
        WordPressClient InitializeClient();
    }
}
