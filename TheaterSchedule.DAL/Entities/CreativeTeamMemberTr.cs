using System;
using System.Collections.Generic;

namespace TheaterSchedule.DAL.Entities
{
    public partial class CreativeTeamMemberTr
    {
        public int CreativeTeamMemberTrid { get; set; }
        public int LanguageId { get; set; }
        public int CreativeTeamMemberId { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }

        public virtual CreativeTeamMember CreativeTeamMember { get; set; }
        public virtual Language Language { get; set; }
    }
}
