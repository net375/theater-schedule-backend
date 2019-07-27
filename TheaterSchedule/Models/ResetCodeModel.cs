using System.ComponentModel.DataAnnotations;
namespace TheaterSchedule.Models
{
    public class ResetCodeModel
    {
        public int Id { get; set; }
        [Required]
        [Range (1000, 9999, ErrorMessage = "Must be 4-number validation code")]
        public int ValidationCode { get; set; }
    }
}
