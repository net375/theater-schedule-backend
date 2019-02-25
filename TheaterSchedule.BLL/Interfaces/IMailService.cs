﻿using System;
using System.Threading.Tasks;
using TheaterSchedule.BLL.DTO;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IMailService
    {
        Task Send(EmailMessageDTO messageDTO);
    }
}
