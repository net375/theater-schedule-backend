using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using Entities.Models;

namespace TheaterSchedule.BLL.Services
{
    public class MessageService : IMessageService
    {
        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private IMessageRepository messageRepository;
        private IAccountRepository accountRepository;


        public MessageService(ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork, IMessageRepository messageRepository,
            IAccountRepository accountRepository)
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.messageRepository = messageRepository;
            this.accountRepository = accountRepository;
        }

        public MessageDTO GetById(int id)
        {
            Message message = messageRepository.GetMessageById(id);
            if (message == null)
            {
                return null;
            }
            return new MessageDTO { MessageId = message.MessageId, Subject = message.Subject, MessageText=message.MessageText };
        }

        public void SendMessage(MessageDTO newMessage)
        {
            Account account = accountRepository.GetAccountByPhoneId(newMessage.PhoneId);
            if (account == null)
            {
                throw new ArgumentException("Non existent account");
            }

            var message = new Message()
            {
                Subject = newMessage.Subject,
                MessageText = newMessage.MessageText,
                AccountId = account.AccountId
            };

            messageRepository.Add(message);
            theaterScheduleUnitOfWork.Save();
        }
    }
}
