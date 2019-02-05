using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("CreativeTeamMember_TR")]
    public partial class CreativeTeamMemberTr
    {
        [Column("CreativeTeamMember_TRId")]
        public int CreativeTeamMemberTrid { get; set; }
        public int LanguageId { get; set; }
        public int CreativeTeamMemberId { get; set; }
        [Required]
        [StringLength(50)]
        public string FistName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [ForeignKey("CreativeTeamMemberId")]
        [InverseProperty("CreativeTeamMemberTr")]
        public virtual CreativeTeamMember CreativeTeamMember { get; set; }
        [ForeignKey("LanguageId")]
        [InverseProperty("CreativeTeamMemberTr")]
        public virtual Language Language { get; set; }
    }
}
