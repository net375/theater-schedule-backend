using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheaterSchedule.Models
{
    public class ChangeProfileModel
    {
        [Required(ErrorMessage = "Required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "Required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required")]
        public string PhoneNumber { get; set; }
    }
}
