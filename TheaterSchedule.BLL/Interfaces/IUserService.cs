using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.BLL.DTOs;
namespace TheaterSchedule.BLL.Interfaces
{
    public interface IUserService
    {
        ApplicationUserDTO Create(ApplicationUserDTO user, string password);
    }
}
