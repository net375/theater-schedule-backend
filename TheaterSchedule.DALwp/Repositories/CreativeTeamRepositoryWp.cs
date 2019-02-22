using Entities.Models;
using System.Collections.Generic;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
using System.Linq;

namespace TheaterSchedule.DALwp.Repositories
{
    public class CreativeTeamRepositoryWp : ICreativeTeamRepository
    {
        private TheaterDatabaseContext db;

        public CreativeTeamRepositoryWp( TheaterDatabaseContext context )
        {
            db = context;
        }

        public IEnumerable<TeamMember>
            GetCreativeTeamByPerformanceId( int performanceId )
        {
            IEnumerable<TeamMember> resultCreativeTeam = null;

            resultCreativeTeam = from performance in db.Performance
                                 join performanceCreativeTeamMember in db.PerformanceCreativeTeamMember
                                     on performance.PerformanceId
                                     equals performanceCreativeTeamMember.PerformanceId
                                 join performanceCreativeTeamMemberTr in db.PerformanceCreativeTeamMemberTr
                                     on performanceCreativeTeamMember.PerformanceCreativeTeamMemberId
                                     equals performanceCreativeTeamMemberTr.PerformanceCreativeTeamMemberId
                                 join creativeTeamMember in db.CreativeTeamMember
                                     on performanceCreativeTeamMember.CreativeTeamMemberId
                                     equals creativeTeamMember.CreativeTeamMemberId
                                 join creativeTeamMemberTr in db.CreativeTeamMemberTr
                                     on creativeTeamMember.CreativeTeamMemberId
                                     equals creativeTeamMemberTr.CreativeTeamMemberId
                                 join language in db.Language
                                     on creativeTeamMemberTr.LanguageId
                                     equals language.LanguageId
                                 select new TeamMember()
                                 {
                                     FirstName = creativeTeamMemberTr.FistName,
                                     LastName = creativeTeamMemberTr.LastName,
                                     Role = performanceCreativeTeamMemberTr.Role
                                 };

            return resultCreativeTeam;
        }
    }
}
