using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IMessageRepository
    {
        void Add(Message message);
        Message GetMessageById(int id);
        List<Message> GetUnrepliedMessages();
    }
}
