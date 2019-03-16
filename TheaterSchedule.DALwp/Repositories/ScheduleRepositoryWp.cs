using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
using WordPressPCL;

namespace TheaterSchedule.DALwp.Repositories
{
    public class ScheduleRepositoryWp : Repository, IScheduleRepositoryWp
    {
        private const int PERFORMANCES_PER_PAGE = 100;
        private const string CUSTOM_URL = "wp/v2/performance";

        private int GetTotalPages(string uri)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(uri);
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            int totalPages = (int) Math.Ceiling(
                double.Parse(response.Headers["X-WP-TotalPages"]) / PERFORMANCES_PER_PAGE);

            return totalPages;
        }

        private class RenderedItem : WordPressPCL.Models.Base
        {
            [JsonProperty("rendered", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public string Rendered { get; set; }
        }

        private class AboutGroup : WordPressPCL.Models.Base
        {
            [JsonProperty("schedule", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public object Schedule { get; set; }
        }

        private class ACF : WordPressPCL.Models.Base
        {
            [JsonProperty("about_group", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public AboutGroup AboutGroup { get; set; }
        }

        private class Performance : WordPressPCL.Models.Base
        {
            [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public int PerformanceId { get; set; }

            [JsonProperty("title", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public RenderedItem Title { get; set; }

            [JsonProperty("featured_media", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public int Featured_media { get; set; }

            [JsonProperty("acf", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public ACF AcfInfo { get; set; }
        }

        private class Media_detailsItem : WordPressPCL.Models.Base
        {
            [JsonProperty("sizes", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public SizesItem Sizes { get; set; }
        }

        private class SizesItem : WordPressPCL.Models.Base
        {
            [JsonProperty("large", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public ImageItem Large { get; set; }

            [JsonProperty("full", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public ImageItem Full { get; set; }
        }

        private class ImageItem : WordPressPCL.Models.Base
        {
            [JsonProperty("source_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public string Source_url { get; set; }
        }

        private class Media : WordPressPCL.Models.Base
        {
            [JsonProperty("media_details", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public Media_detailsItem Media_details { get; set; }
        }

        private async Task<IEnumerable<Performance>> GetPerformances(WordPressClient client)
        {
            string uriForGettingTotalPages = $"{client.WordPressUri}{CUSTOM_URL}?per_page=1";
            int totalPages = GetTotalPages(uriForGettingTotalPages);

            List<Performance> performances = new List<Performance>();
            IEnumerable<Performance> newPerformances = null;
            string customRequest = $"wp/v2/performance?per_page=100&page=";

            for (int i = 1; i <= totalPages; ++i) // i equals 1 at the beginning for more convenient creating of url
            {
                newPerformances = await client.CustomRequest
                    .Get<IEnumerable<Performance>>($"{customRequest}{i}");
                performances.AddRange(newPerformances);
            }

            return newPerformances;
        }

        private static async Task<IEnumerable<Media>> GetMediaOfPerformance(WordPressClient client, int perforamanceId)
        {
            return await client.CustomRequest.Get<IEnumerable<Media>>($"wp/v2/media?parent={perforamanceId}");
        }

        public IEnumerable<ScheduleDataModelWp> GetPerformancesByDateRange(string languageCode,
            DateTime? startDate, DateTime? endDate)
        {
            var performances = GetPerformances(InitializeClient()).Result;
            List<ScheduleDataModelWp> schedule = new List<ScheduleDataModelWp>();
            int index = 0;
            foreach (var performance in performances)
            {
                var scheduleObj = performance.AcfInfo.AboutGroup.Schedule;

                if (Convert.ToString(scheduleObj).ToLower() == "false")
                    continue;
                else
                {
                    var scheduleList = JArray.Parse(scheduleObj.ToString()).Last.Last.Last
                        .Children();

                    foreach (var scheduleItem in scheduleList)
                    {
                        var property = scheduleItem.Children().Children().ToList();
                        DateTime dateOnly = DateTime.ParseExact(property[0].ToString(), "dd/MM/yyyy", null);
                        DateTime timeOnly = Convert.ToDateTime(property[1]);
                        DateTime beginningDate = dateOnly.Date.Add(timeOnly.TimeOfDay);

                        if ((!startDate.HasValue || beginningDate >= startDate) &&
                            (!endDate.HasValue || beginningDate <= endDate))
                        {
                            schedule.Add(new ScheduleDataModelWp()
                            {
                                PerformanceId = performance.PerformanceId,
                                ScheduleId = index++,
                                Title = performance.Title.Rendered,
                                Beginning = beginningDate,
                                redirectToTicket = Convert.ToString(property[2])
                            });
                        }
                    }
                }
            }

            schedule.Sort((x, y) => x.Beginning.CompareTo(y.Beginning));

            return schedule;
        }
    }
}
