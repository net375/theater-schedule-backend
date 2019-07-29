using System;
using System.ComponentModel.DataAnnotations;

namespace TheaterSchedule.BLL.DTOs
{
    public class ApplicationUserDTO
    {
        public int Id { get; set;}

        [Required(ErrorMessage = "You should enter your firstname")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You should enter your lastname")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You should enter your birth date")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "You should enter your city")]
        public string City { get; set; }

        [Required(ErrorMessage = "You should enter your country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "You should enter your email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required", AllowEmptyStrings = false)]
        [MinLength(6)]
        public string Password { get; set; }
        
        public string PhoneIdentifier { get; set; }

        public int? SettingsId { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$", ErrorMessage = "Phone Number is not valid")]

        public string PhoneNumber { get; set; }

    }
}