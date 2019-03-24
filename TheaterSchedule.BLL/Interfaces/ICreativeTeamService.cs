using System.Collections.Generic;
using TheaterSchedule.BLL.DTO;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface ICreativeTeamService
    {
        IEnumerable<TeamMember> LoadCreativeTeam(
            string languageCode, int performanceId );
    }
}
