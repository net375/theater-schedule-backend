using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TheaterSchedule.DAL.Models
{
    public class ApplicationUserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneIdentifier { get; set; }
        public int SettingsId { get; set; }
        public string PhoneNumber { get; set; }

    }
}
