using System;
using System.Collections.Generic;

namespace TheaterSchedule.DAL.Entities
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
        public string LanguageName { get; set; }

        public virtual ICollection<CreativeTeamMemberTr> CreativeTeamMemberTr { get; set; }
        public virtual ICollection<HashTagTr> HashTagTr { get; set; }
        public virtual ICollection<PerformanceCreativeTeamMemberTr> PerformanceCreativeTeamMemberTr { get; set; }
        public virtual ICollection<PerformanceTr> PerformanceTr { get; set; }
        public virtual ICollection<Settings> Settings { get; set; }
    }
}
