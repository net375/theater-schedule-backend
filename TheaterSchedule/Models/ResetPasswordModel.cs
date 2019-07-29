using System.ComponentModel.DataAnnotations;

namespace TheaterSchedule.Models
{
    public class ResetPasswordModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
