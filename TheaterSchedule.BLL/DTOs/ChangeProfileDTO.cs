using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterSchedule.BLL.DTOs
{
    public class ChangeProfileDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
