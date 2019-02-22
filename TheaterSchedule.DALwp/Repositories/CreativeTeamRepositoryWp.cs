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

            resultCreativeTeam = from ctmTr in db.CreativeTeamMemberTr
                join ctm in db.CreativeTeamMember 
                    on ctmTr.CreativeTeamMemberId 
                    equals ctm.CreativeTeamMemberId
                join pctm in db.PerformanceCreativeTeamMember 
                    on ctm.CreativeTeamMemberId 
                    equals pctm.CreativeTeamMemberId
                join pctmTr in db.PerformanceCreativeTeamMemberTr 
                    on pctm.PerformanceCreativeTeamMemberId 
                    equals pctmTr.PerformanceCreativeTeamMemberId
                    into pctmTrJoin
                from role in pctmTrJoin.DefaultIfEmpty()
                    where (pctm.PerformanceId == performanceId)
                select new TeamMember
                {
                    Role = role.Role,
                    FirstName = ctmTr.FistName,
                    LastName = ctmTr.LastName,
                };

            return resultCreativeTeam;
        }
    }
}
