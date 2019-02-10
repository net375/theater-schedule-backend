using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.BLL.DTO;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IMessageService
    {
        MessageDTO GetById(int id);
        void SendMessage(MessageDTO newMessage);
    }
}
