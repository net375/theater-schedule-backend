using TheaterSchedule.BLL.DTO;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface ITagService
    {
        Tag LoadTagsById(int id);
    }
}
