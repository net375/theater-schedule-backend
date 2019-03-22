using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;

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

    public class PerfomanceRepositoryWp : Performance, IPerfomanceRepository
    {
        private const int PERFORMANCES_PER_PAGE = 100;
        private const string CUSTOM_URL = "wp/v2/performance";

        private int GetTotalPages(string uri)
        {
            HttpWebRequest request = ( HttpWebRequest )WebRequest.Create( uri );
            HttpWebResponse response = ( HttpWebResponse )request.GetResponse();
            int totalPages = (int)Math.Ceiling(
                double.Parse(response.Headers["X-WP-TotalPages"]) / PERFORMANCES_PER_PAGE);

            return totalPages;
        }

        private async Task<IEnumerable<PerformanceDataModel>> 
            GetPerformanceTitlesAndImagesAsync(string languageCode)
        {
            //no localisation yet

            var client = new Repository().InitializeClient();
            string uriForGettingTotalPages = $"{client.WordPressUri}{CUSTOM_URL}?per_page=1";
            int totalPages = GetTotalPages( uriForGettingTotalPages );

            List<Performance> performances = new List<Performance>();
            IEnumerable<Performance> newPerformances = null;
            string customRequest = $"wp/v2/performance?per_page=100&page=";

            for (int i = 1; i <= totalPages; ++i)   // i equals 1 at the beginning for more convenient creating of url
            {
                newPerformances = await client.CustomRequest
                    .Get<IEnumerable<Performance>>($"{customRequest}{i}" );
                performances.AddRange(newPerformances);
            }

            List<PerformanceDataModel> performancesData = performances.Select(
                p => new PerformanceDataModel
                {
                    PerformanceId = p.Id,
                    Title = WebUtility.HtmlDecode( p.Title.Rendered ),
                    MainImageUrl = client.CustomRequest.Get<Media>(
                        $"wp/v2/media/{p.Featured_media}").Result.Media_details.Sizes.Full.Source_url
                }).ToList();

            return performancesData;
        }

        List<PerformanceDataModel> IPerfomanceRepository.GetPerformanceTitlesAndImages(string languageCode)
        {
            return GetPerformanceTitlesAndImagesAsync(languageCode).Result.ToList();
        }
    }
}
