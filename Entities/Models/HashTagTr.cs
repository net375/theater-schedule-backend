using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("HashTag_TR")]
    public partial class HashTagTr
    {
        [Column("HashTag_TRId")]
        public int HashTagTrid { get; set; }
        [Required]
        [StringLength(30)]
        public string Tag { get; set; }
        public int LanguageId { get; set; }
        public int HashTagId { get; set; }

        [ForeignKey("HashTagId")]
        [InverseProperty("HashTagTr")]
        public virtual HashTag HashTag { get; set; }
        [ForeignKey("LanguageId")]
        [InverseProperty("HashTagTr")]
        public virtual Language Language { get; set; }
    }
}
