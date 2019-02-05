using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public partial class Language
    {
        public Language()
        {
            CreativeTeamMemberTr = new HashSet<CreativeTeamMemberTr>();
            HashTagTr = new HashSet<HashTagTr>();
            PerformanceCreativeTeamMemberTr = new HashSet<PerformanceCreativeTeamMemberTr>();
            PerformanceTr = new HashSet<PerformanceTr>();
            Settings = new HashSet<Settings>();
        }

        public int LanguageId { get; set; }
        [Required]
        [StringLength(30)]
        public string LanguageName { get; set; }

        [InverseProperty("Language")]
        public virtual ICollection<CreativeTeamMemberTr> CreativeTeamMemberTr { get; set; }
        [InverseProperty("Language")]
        public virtual ICollection<HashTagTr> HashTagTr { get; set; }
        [InverseProperty("Language")]
        public virtual ICollection<PerformanceCreativeTeamMemberTr> PerformanceCreativeTeamMemberTr { get; set; }
        [InverseProperty("Language")]
        public virtual ICollection<PerformanceTr> PerformanceTr { get; set; }
        [InverseProperty("Language")]
        public virtual ICollection<Settings> Settings { get; set; }
    }
}
