using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostersController : ControllerBase
    {
        IPostersService postersService;
        IMemoryCache memoryCache;

        public PostersController(IPostersService postersService, IMemoryCache memoryCache)
        {
            this.postersService = postersService;
            this.memoryCache = memoryCache;
        }

        // GET: api/Posters
        [HttpGet("{languageCode}")]
        public async Task<List<PostersDTO>> Get(string languageCode)
        {
            List<PostersDTO> performancesData = null;
            string memoryCacheKey = "PerformanceList";
            int expirationTimeInHours = 12;
            if (!memoryCache.TryGetValue(memoryCacheKey, out performancesData))
            {
                performancesData = await postersService.LoadPostersData(languageCode);
                var cacheEntryOptions = new MemoryCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(expirationTimeInHours)};
                memoryCache.Set(memoryCacheKey, performancesData, cacheEntryOptions);
            }
            return performancesData;
        }
    }
}
