using System.Collections.Generic;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DALwp.Fake_Repositories
{
    public class CreativeTeamRepositoryWpFake : ICreativeTeamRepository
    {
        public IEnumerable<TeamMember> GetCreativeTeam( string languageCode, int performanceId )
        {
            return new List<TeamMember>
            {
                new TeamMember
                {
                    FirstName = "Vasyl",
                    LastName = "Diakiv",
                    Role = "Producer",
                    RoleKey = "PRODUCER"
                },
                new TeamMember
                {
                    FirstName = "Vlad",
                    LastName = "Mamai",
                    Role = "Painter",
                    RoleKey = "PAINTER"
                },
                new TeamMember
                {
                    FirstName = "Oleh",
                    LastName = "Sihunov",
                    Role = "Composer",
                    RoleKey = "COMPOSER"
                }
            };
        }
    }
}
