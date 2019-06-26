using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.BLL.DTOs;
using TheaterSchedule.BLL.Interfaces;
namespace TheaterSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private IUserService service;
        public RegistrationController(IUserService service)
        {
            this.service = service;
        }

        public ActionResult CreateUser()
        {
            ApplicationUserDTO user = new ApplicationUserDTO
            {
                City = "Lviv",
                Country = "Ukraine",
                DateOfBirth = new DateTimeOffset(DateTime.Now),
                Email = "alex.danyuk@outlook.com",
                FirstName = "alex",
                LastName = "danyuk",
                Id = 1,
                Password = "string"
            };
            service.Create(user, user.Password);
            return Ok();
    }
}
}