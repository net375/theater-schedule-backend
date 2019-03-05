using System.Collections.Generic;
using TheaterSchedule.DAL.Interfaces;
using System.Threading.Tasks;
using TheaterSchedule.DAL.Models;
using Newtonsoft.Json;

namespace TheaterSchedule.DALwp.Repositories
{
    public class CreativeTeamRepositoryWp : Repository, ICreativeTeamRepository
    {
        private class TeamMemberWp : WordPressPCL.Models.Base
        {
            [JsonProperty( "rendered", DefaultValueHandling = DefaultValueHandling.Ignore )]
            public string FirstName { get; set; }

            [JsonProperty( "rendered", DefaultValueHandling = DefaultValueHandling.Ignore )]
            public string LastName { get; set; }

            [JsonProperty( "rendered", DefaultValueHandling = DefaultValueHandling.Ignore )]
            public string Role { get; set; }

            [JsonProperty( "rendered", DefaultValueHandling = DefaultValueHandling.Ignore )]
            public string RoleKey { get; set; }
        }

        private async Task<IEnumerable<TeamMemberWp>> GetCreativeTeamFromWpApi(
            string languageCode, int performanceId )
        {
            return await InitializeClient().CustomRequest
                .Get<IEnumerable<TeamMemberWp>>(
                    $"wp/v2/{languageCode}/performance/{performanceId}/creativeteam" );
        }

        private IEnumerable<TeamMember> ConvertTeamMemberWpToTeamMember(
            IEnumerable<TeamMemberWp> creativeTeamWp)
        {
            List<TeamMember> creativeTeam = new List<TeamMember>();

            foreach ( var creativeTeamMemberWp in creativeTeamWp)
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

        public IEnumerable<TeamMember> GetCreativeTeam( string languageCode, int performanceId )
        {
            var taskResult = GetCreativeTeamFromWpApi( languageCode, performanceId );
            
            return ConvertTeamMemberWpToTeamMember(taskResult.Result);
        }
    }
}
