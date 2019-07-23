using System.ComponentModel.DataAnnotations;

namespace TheaterSchedule.Models
{
    public class ChangeProfileModel
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Birth Date is required")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "City is required")]
        [DataType(DataType.Text)]
        public string City { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [DataType(DataType.Text)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$", ErrorMessage = "Phone Number is not valid")]
        public string PhoneNumber { get; set; }
    }
}
