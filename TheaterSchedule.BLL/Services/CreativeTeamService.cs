﻿using AutoMapper;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
using TeamMember = TheaterSchedule.BLL.DTO.TeamMember;

namespace TheaterSchedule.BLL.Services
{
    public class CreativeTeamService : ICreativeTeamService
    {
        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private ICreativeTeamRepository creativeTeamRepository;
        private IMemoryCache memoryCache;

        public CreativeTeamService(
            ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork,
            ICreativeTeamRepository creativeTeamRepository,
            IMemoryCache memoryCache )
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.creativeTeamRepository = creativeTeamRepository;
            this.memoryCache = memoryCache;
        }

        public IEnumerable<TeamMember> LoadCreativeTeam(
            string languageCode, int performanceId )
        {
            var mapper = new MapperConfiguration(
                cfg => cfg.CreateMap<DAL.Models.TeamMember, TeamMember>() )
                .CreateMapper();
            IEnumerable<DAL.Models.TeamMember> creativeTeam = null;
            string cacheKey = GetCacheKey(languageCode, performanceId);

            if (!memoryCache.TryGetValue(cacheKey, out creativeTeam))
            {
                creativeTeam = creativeTeamRepository.GetCreativeTeam(languageCode, performanceId);
                memoryCache.Set(cacheKey, creativeTeam);
            }

            return mapper.Map<IEnumerable<DAL.Models.TeamMember>, IEnumerable<TeamMember>>(creativeTeam);
        }

        private string GetCacheKey(string languageCode, int id)
        {
            return $"TeamMember {languageCode} {id}";
        }
    }
}
