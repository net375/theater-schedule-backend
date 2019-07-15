using System.ComponentModel.DataAnnotations;

namespace TheaterSchedule.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
