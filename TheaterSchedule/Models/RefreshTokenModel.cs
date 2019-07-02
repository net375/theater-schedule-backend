
using System.ComponentModel.DataAnnotations;

namespace TheaterSchedule.Models
{
    public class RefreshTokenModel
    {
        [Required(ErrorMessage = "Required", AllowEmptyStrings = false)]
        public string RefreshToken { get; set; }
    }
}
