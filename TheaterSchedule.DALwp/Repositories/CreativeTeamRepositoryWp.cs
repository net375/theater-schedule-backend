using System.Collections.Generic;
using TheaterSchedule.DAL.Interfaces;
using System.Threading.Tasks;
using WordPressPCL;
using TheaterSchedule.DALwp.Models;
using Entities.Models;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DALwp.Repositories
{
    public class CreativeTeamRepositoryWp : ICreativeTeamRepository
    {
        private TheaterDatabaseContext db;

        public CreativeTeamRepositoryWp( TheaterDatabaseContext context )
        {
            db = context;
        }

        private async Task<IEnumerable<CreativeTeamMemberWp>> GetCreativeTeamFromWPApi(
            string languageCode, int performanceId )
        {
            var client = new WordPressClient( "https://lvivpuppet.com/wp-json" );

            return await client.CustomRequest
                .Get<IEnumerable<CreativeTeamMemberWp>>(
                    $"wp/v2/{languageCode}/performance/{performanceId}/creativeteam" );
        }

        public IEnumerable<TeamMember> GetCreativeTeam( string languageCode, int performanceId )
        {
            var taskResult = GetCreativeTeamFromWPApi( languageCode, performanceId );
            List<TeamMember> creativeTeam = new List<TeamMember>();

            foreach ( var creativeTeamMemberWp in taskResult.Result )
            {
                creativeTeam.Add( new TeamMember
                {
                    FirstName = creativeTeamMemberWp.FirstName,
                    LastName = creativeTeamMemberWp.LastName,
                    Role = creativeTeamMemberWp.Role,
                    RoleKey = creativeTeamMemberWp.RoleKey
                } );
            }
            
            return creativeTeam;
        }
    }
}
