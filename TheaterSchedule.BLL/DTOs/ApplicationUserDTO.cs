using System;
using System.ComponentModel.DataAnnotations;

namespace TheaterSchedule.BLL.DTOs
{
    public class ApplicationUserDTO
    {
        [Required]
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

        [Required(ErrorMessage ="You should enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required]
        public string PhoneIdentifier { get; set; }

        [Required]
        public int? SettingsId { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$", ErrorMessage = "Phone Number is not valid")]

        public string PhoneNumber { get; set; }

    }
}
