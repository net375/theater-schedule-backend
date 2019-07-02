using System;
using System.ComponentModel.DataAnnotations;

namespace TheaterSchedule.BLL.DTOs
{
    public class ApplicationUserDTO
    {
        public int Id { get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string PhoneIdentifier { get; set; }
        public int? SettingsId { get; set; }
        public string PnoneNumber { get; set; }

    }
}
