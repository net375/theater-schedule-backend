using System.Collections.Generic;
using System.Threading.Tasks;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.DTOs;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IMessageService
    {
        MessageDTO GetById(int id);
        Task SendMessage(MessageDTO newMessage);

        List<UserMessageDTO> GetAllMessages();
    }
}
