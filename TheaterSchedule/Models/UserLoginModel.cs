using System.ComponentModel.DataAnnotations;

namespace TheaterSchedule.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Required", AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required", AllowEmptyStrings = false)]
        public string PasswordHash { get; set; }
    }
}
