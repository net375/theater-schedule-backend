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
    public class ScheduleRepositoryWp : Repository, IScheduleRepository
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

        // Information about performance (Main Image)

        #region Access to Main Image

        private class Media : WordPressPCL.Models.Base
        {
            [JsonProperty("media_details", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public Media_detailsItem Media_details { get; set; }
        }

        private class Media_detailsItem : WordPressPCL.Models.Base
        {
            [JsonProperty("sizes", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public SizesItem Sizes { get; set; }
        }

        private class SizesItem : WordPressPCL.Models.Base
        {
            [JsonProperty("full", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public FullItem Full { get; set; }
        }

        private class FullItem : WordPressPCL.Models.Base
        {
            [JsonProperty("source_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public string Source_url { get; set; }
        }

        #endregion

        // Information about performance (Schedule)

        #region Access to Schedule

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

        private class ACF : WordPressPCL.Models.Base
        {
            [JsonProperty("about_group", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public AboutGroup AboutGroup { get; set; }
        }

        private class AboutGroup : WordPressPCL.Models.Base
        {
            //Type object, because if in 'schedule' data not exists, it returns not 'null', but 'false' and after that throws exception

            [JsonProperty("schedule", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public object Schedule { get; set; }
        }

        private class RenderedItem : WordPressPCL.Models.Base
        {
            [JsonProperty("rendered", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public string Rendered { get; set; }
        }

        #endregion

        private async Task<IEnumerable<Performance>> GetPerformances(WordPressClient client)
        {
            string uriForGettingTotalPages = $"{client.WordPressUri}{CUSTOM_URL}?per_page=1";
            int totalPages = GetTotalPages(uriForGettingTotalPages);

            List<Performance> performances = new List<Performance>();
            IEnumerable<Performance> newPerformances = null;
            string customRequest = $"wp/v2/performance?per_page=100&page=";

            for (int i = 1; i <= totalPages; ++i)
            {
                newPerformances = await client.CustomRequest
                    .Get<IEnumerable<Performance>>($"{customRequest}{i}");
                performances.AddRange(newPerformances);
            }

            return newPerformances;
        }

        private static async Task<Media> GetMainImage(WordPressClient client, int featured_media)
        {
            return await client.CustomRequest.Get<Media>($"wp/v2/media/{featured_media}");
        }

        public IEnumerable<ScheduleDataModelBase> GetListPerformancesByDateRange(string languageCode,
            DateTime? startDate, DateTime? endDate)
        {
            // No localization yet
            //'EndDate' not needed anymore, it will be deleted if delete ScheduleRepository for DB 

            var performances = GetPerformances(InitializeClient()).Result;
            List<ScheduleDataModelWp> schedule = new List<ScheduleDataModelWp>();

            foreach (var performance in performances)
            {
                var scheduleObj = performance.AcfInfo.AboutGroup.Schedule;

                if (Convert.ToString(scheduleObj).ToLower() == "false")
                    continue;
                else
                {
                    var media = GetMainImage(InitializeClient(), performance.Featured_media).Result;

                    var scheduleList = JArray.Parse(scheduleObj.ToString()).Last.Last.Last
                        .Children();

                    foreach (var scheduleItem in scheduleList)
                    {
                        var property = scheduleItem.Children().Children().ToList();
                        DateTime dateOnly = DateTime.ParseExact(property[0].ToString(), "dd/MM/yyyy", null);
                        DateTime timeOnly = Convert.ToDateTime(property[1]);
                        DateTime beginningDate = dateOnly.Date.Add(timeOnly.TimeOfDay);

                        if (!startDate.HasValue || beginningDate >= startDate && beginningDate <= startDate.Value.AddMonths(1))
                        {
                            schedule.Add(new ScheduleDataModelWp()
                            {
                                PerformanceId = performance.PerformanceId,
                                MainImage = media.Media_details.Sizes.Full.Source_url,
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
