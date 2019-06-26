﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterSchedule.DAL.Models
{
    public class ApplicationUserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
