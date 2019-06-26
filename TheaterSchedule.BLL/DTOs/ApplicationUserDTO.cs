using System;

namespace TheaterSchedule.BLL.DTOs
{
    public class ApplicationUserDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
