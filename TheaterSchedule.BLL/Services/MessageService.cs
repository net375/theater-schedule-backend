using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using Entities.Models;
using TheaterSchedule.DAL.Models;
using AutoMapper;
using TheaterSchedule.BLL.DTOs;

namespace TheaterSchedule.BLL.Services
{
    public class MessageService : IMessageService
    {
        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private IMessageRepository messageRepository;
        private IUserRepository userRepository;
        private IMapper _mapper;

        public MessageService(
            ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork, 
            IMessageRepository messageRepository,
             IUserRepository userRepository)
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.messageRepository = messageRepository;
            this.userRepository = userRepository;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Message, MessageDTO>().ReverseMap();
            }).CreateMapper();

        }

        public MessageDTO GetById(int id)
        {
            Entities.Models.Message message = messageRepository.GetMessageById(id);
            if (message == null)
            {
                return null;
            }

            return _mapper.Map<MessageDTO>(message);
        }

        public async Task SendMessage(MessageDTO newMessage)
        {
            var account = userRepository.GetById(newMessage.AccountId);

            if (account == null)
            {
                throw new NullReferenceException();
            }

            var message = _mapper.Map<Message>(newMessage);

            messageRepository.Add(message);
            await theaterScheduleUnitOfWork.SaveAsync();
        }

        public List<UserMessageDTO> GetAllMessages()
        {
            var messages = messageRepository.GetUnrepliedMessages();

            var users = userRepository.GetAll().ToList();

            if (messages == null)
            {
                throw new ArgumentException("Not found messages");
            }

            var result = from m in messages
                join u in users on m.AccountId equals u.AccountId
                select new UserMessageDTO{MessageId = m.MessageId,Subject = m.Subject,MessageText = m.MessageText,
                    AccountId = m.AccountId,FirstName = u.FirstName, LastName = u.LastName, Email = u.Email};

            return result.ToList();
        }
    }
}
