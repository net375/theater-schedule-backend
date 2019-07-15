using System.ComponentModel.DataAnnotations;
namespace TheaterSchedule.Models
{
    public class ResetCodeModel
    {
        [Required]
        public int Code { get; set; }
    }
}
