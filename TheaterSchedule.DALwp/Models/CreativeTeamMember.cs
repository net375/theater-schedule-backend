using Newtonsoft.Json;

namespace TheaterSchedule.DALwp.Models
{
    public class CreativeTeamMemberWp : WordPressPCL.Models.Base
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
}
