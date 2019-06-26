<<<<<<< HEAD
﻿using System;

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
=======
﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterSchedule.BLL.DTOs
{
    public class ApplicationUserDTO
    {
        public int Id { get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
>>>>>>> f414a2dbb0e41c6b588ab62e478e6ecaddb76256
