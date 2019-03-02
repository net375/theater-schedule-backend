using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
using WordPressPCL;

namespace TheaterSchedule.DALwp.Repositories
{

    public class TitleItem : WordPressPCL.Models.Base
    {
        [JsonProperty("rendered", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Rendered { get; set; }
    }

    public class Performance : WordPressPCL.Models.Base
    {
        [JsonProperty("title", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public TitleItem Title { get; set; }

        [JsonProperty("date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime Date { get; set; }

        [JsonProperty("featured_media", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Featured_media { get; set; }
    }

    public class Media_detailsItem : WordPressPCL.Models.Base
    {
        [JsonProperty("sizes", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public SizesItem Sizes { get; set; }
    }

    public class SizesItem : WordPressPCL.Models.Base
    {
        [JsonProperty("full", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public FullItem Full { get; set; }
    }

    public class FullItem : WordPressPCL.Models.Base
    {
        [JsonProperty("source_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Source_url { get; set; }
    }

    public class Media : WordPressPCL.Models.Base
    {
        [JsonProperty("media_details", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Media_detailsItem Media_details { get; set; }
    }

    public class PerfomanceRepositoryWp : IPerfomanceRepository
    {

        public async Task<IEnumerable<PerformanceDataModel>> GetPerformanceTitlesAndImagesAsync(string languageCode)
        {
            //no localisation yet
           
                var client = new WordPressClient("https://lvivpuppet.com/wp-json");
                var performances = await client.CustomRequest.Get<IEnumerable<Performance>>($"wp/v2/performance");
                List<Media> medias = new List<Media>();
                foreach (var p in performances)
                {
                    medias.Add(await client.CustomRequest.Get<Media>($"wp/v2/media/{p.Featured_media}"));
                }
            List<PerformanceDataModel> performancesData = performances.Join(medias,
                   p => p.Featured_media,
                   m => m.Id,
                   (p, m) => new PerformanceDataModel()
                   {
                       PerformanceId = p.Id,
                       Title = p.Title.Rendered,
                       MainImageUrl = m.Media_details.Sizes.Full.Source_url
                   }).ToList();            
            
            return performancesData;
        }
    }
}
