using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public partial class Schedule
    {
        public Schedule()
        {
            Watchlist = new HashSet<Watchlist>();
        }

        public int ScheduleId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Beginning { get; set; }
        public int PerformanceId { get; set; }

        [ForeignKey("PerformanceId")]
        [InverseProperty("Schedule")]
        public virtual Performance Performance { get; set; }
        [InverseProperty("Schedule")]
        public virtual ICollection<Watchlist> Watchlist { get; set; }
    }
}
