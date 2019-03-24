using TheaterSchedule.BLL.DTO;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IMessageService
    {
        Message GetById(int id);
        void SendMessage(Message newMessage);
    }
}
