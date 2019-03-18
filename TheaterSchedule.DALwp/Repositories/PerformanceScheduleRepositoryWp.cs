using System.Collections.Generic;
using System;
using WordPressPCL;
using Newtonsoft.Json;
using System.Threading.Tasks;
using TheaterSchedule.DAL.Models;
using TheaterSchedule.DAL.Interfaces;
using System.Linq;

namespace TheaterSchedule.DALwp.Repositories
{
    public class PerformanceScheduleRepositoryWp : Repository, IPerformanceScheduleRepository
    {
        private class ScheduleDetails : WordPressPCL.Models.Base
        {
            [JsonProperty("schedule_day", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public string ScheduleDay { get; set; }

            [JsonProperty("schedule_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public string ScheduleTime { get; set; }

            [JsonProperty("schedule_link", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public string ScheduleLink { get; set; }
        }

        private class Schedule
        {
            [JsonProperty("year_field", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public object Year { get; set; }
            [JsonProperty("month_field", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public object Month { get; set; }
            [JsonProperty("schedule_shows", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public IEnumerable<ScheduleDetails> scheduleDetails { get; set; }
        }

        private class AboutGroup : WordPressPCL.Models.Base
        {
            [JsonProperty("schedule")]
            public IEnumerable<Schedule> schedule { get; set; }

            [JsonProperty("age", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public int Age { get; set; }

            [JsonProperty("price", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public string Price { get; set; }

            [JsonProperty("duration", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public int Duration { get; set; }
        }

        private class ACF : WordPressPCL.Models.Base
        {
            [JsonProperty("about_group", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public AboutGroup aboutGroup { get; set; }
        }

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

        private class Performance : WordPressPCL.Models.Base
        {
            [JsonProperty("title", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public RenderedItem Title { get; set; }
            [JsonProperty("acf", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public ACF AcfInfo { get; set; }
            [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public int PerformanceId { get; set; }
            [JsonProperty("featured_media", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public int Featured_media { get; set; }
        }

        private class RenderedItem : WordPressPCL.Models.Base
        {
            [JsonProperty("rendered", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public string Rendered { get; set; }
        }

        public async Task<PerformanceScheduleDataModel> GetPerfomanceScheduleInfo(int performanceId)
        {
            var client = new Repository().InitializeClient();
            var gettingSchedule = await client.CustomRequest.Get<Performance>($"wp/v2/performance/{performanceId}");
            PerformanceScheduleDataModel dataModel;
            List<PerformanceScheduleDataModelBase> scheduleList = new List<PerformanceScheduleDataModelBase>();

            int PerformanceId = gettingSchedule.PerformanceId;
            string Title = gettingSchedule.Title.Rendered;
            int MediaId = gettingSchedule.Featured_media;
            int Age = gettingSchedule.AcfInfo.aboutGroup.Age;
            int Duration = gettingSchedule.AcfInfo.aboutGroup.Duration;
            string Price = gettingSchedule.AcfInfo.aboutGroup.Price;

            var gettingImages = await client.CustomRequest.Get<Media>($"wp/v2/media/{MediaId}");
            string MainImageUrl = gettingImages.Media_details.Sizes.Full.Source_url;
            

            foreach (var info in gettingSchedule.AcfInfo.aboutGroup.schedule)
            {
                foreach (var schedule in info.scheduleDetails)
                {
                    
                    DateTime date = ConvertStringToDateTime(schedule.ScheduleDay);
                    DateTime time = Convert.ToDateTime(schedule.ScheduleTime);
                    if(date.Date>=DateTime.Now)
                    {
                        if (scheduleList.Exists(tempData => tempData.Day == date))
                        {
                            scheduleList.First(tempData => tempData.Day == date).TimeLinkList.Add(new TimeLink() { Time = time, Link = schedule.ScheduleLink });
                        }
                        else
                        {
                            List<TimeLink> times = new List<TimeLink>() { new TimeLink() { Time = time, Link = schedule.ScheduleLink } };
                            scheduleList.Add(new PerformanceScheduleDataModelBase() { Day = date, TimeLinkList = times });
                        }
                    }
                    
                }
            }

            dataModel = new PerformanceScheduleDataModel()
            {
                PerformanceId = PerformanceId,
                Title = Title,
                MainImage = MainImageUrl,
                ScheduleList = scheduleList,
                Age=Age,
                Duration=Duration,
                Price=Price,
            };

            return dataModel;
        }

        public DateTime ConvertStringToDateTime(string date)
        {
            string pattern = "dd/MM/yyyy";
            DateTime convertedDate = DateTime.ParseExact(date, pattern, null);
            return convertedDate;
        }
    }
}
