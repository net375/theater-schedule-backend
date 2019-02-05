using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public partial class Watchlist
    {
        public int AccountId { get; set; }
        public int ScheduleId { get; set; }

        [ForeignKey("AccountId")]
        [InverseProperty("Watchlist")]
        public virtual Account Account { get; set; }
        [ForeignKey("ScheduleId")]
        [InverseProperty("Watchlist")]
        public virtual Schedule Schedule { get; set; }
    }
}
