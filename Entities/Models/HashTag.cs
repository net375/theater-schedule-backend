using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public partial class HashTag
    {
        public HashTag()
        {
            HashTagPerformance = new HashSet<HashTagPerformance>();
            HashTagTr = new HashSet<HashTagTr>();
        }

        public int HashTagId { get; set; }

        [InverseProperty("HashTag")]
        public virtual ICollection<HashTagPerformance> HashTagPerformance { get; set; }
        [InverseProperty("HashTag")]
        public virtual ICollection<HashTagTr> HashTagTr { get; set; }
    }
}
