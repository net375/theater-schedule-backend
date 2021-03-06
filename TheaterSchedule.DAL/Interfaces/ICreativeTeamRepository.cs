﻿using System.Collections.Generic;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface ICreativeTeamRepository
    {
        IEnumerable<TeamMember>
            GetCreativeTeam( string languageCode, int performanceId );
    }
}
