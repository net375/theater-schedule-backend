using TheaterSchedule.BLL.DTO;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface ITagService
    {
        TagDTO LoadTagsById(int id);
    }
}
