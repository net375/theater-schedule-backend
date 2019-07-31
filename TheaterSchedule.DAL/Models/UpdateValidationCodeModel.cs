using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterSchedule.DAL.Models
{
    public class UpdateValidationCodeModel
    {
        public int Id { get; set; }
        public int ValidationCode { get; set; }
        public DateTime CodeCreationTime { get; set; }
    }
}
