using System.ComponentModel.DataAnnotations;

namespace TheaterSchedule.Models
{
    public class ResetPasswordModel
    {
        [Required]
        public string Password { get; set; }
    }
}
