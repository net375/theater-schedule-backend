using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TheaterSchedule.Models
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required", AllowEmptyStrings = false)]
        [MinLength(6)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Required", AllowEmptyStrings = false)]
        [MinLength(6)]
        public string NewPassword { get; set; }
    }
}
