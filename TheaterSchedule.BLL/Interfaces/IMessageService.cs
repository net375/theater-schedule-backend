using TheaterSchedule.BLL.DTO;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IMessageService
    {
        MessageDTO GetById(int id);
        void SendMessage(MessageDTO newMessage);
    }
}
