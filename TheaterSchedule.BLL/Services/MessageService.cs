using System;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using Entities.Models;
using Message = TheaterSchedule.BLL.DTO.Message;

namespace TheaterSchedule.BLL.Services
{
    public class MessageService : IMessageService
    {
        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private IMessageRepository messageRepository;
        private IAccountRepository accountRepository;


        public MessageService(
            ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork, 
            IMessageRepository messageRepository,
            IAccountRepository accountRepository)
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.messageRepository = messageRepository;
            this.accountRepository = accountRepository;
        }

        public Message GetById(int id)
        {
            Entities.Models.Message message = messageRepository.GetMessageById(id);
            if (message == null)
            {
                return null;
            }
            return new Message
            {
                MessageId = message.MessageId,
                Subject = message.Subject
            };
        }

        public void SendMessage(Message newMessage)
        {
            Account account = accountRepository.GetAccountByPhoneId(newMessage.PhoneId);
            if (account == null)
            {
                throw new ArgumentException("Non existent account");
            }

            var message = new Entities.Models.Message()
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
