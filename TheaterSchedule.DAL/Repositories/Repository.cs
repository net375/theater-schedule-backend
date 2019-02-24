using WordPressPCL;
using TheaterSchedule.DAL.Interfaces;


namespace TheaterSchedule.DAL.Repositories
{
    public class Repository: IRepository
    {
        static string uri = "https://lvivpuppet.com/wp-json";

        public WordPressClient InitializeClient()
        {
            return new WordPressClient(uri);
        }

    }
}
