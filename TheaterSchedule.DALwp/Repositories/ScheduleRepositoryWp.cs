using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
using WordPressPCL;

namespace TheaterSchedule.DALwp.Repositories
{
    public class ScheduleRepositoryWp: Repository, IScheduleRepository
    {
        private const int PERFORMANCES_PER_PAGE = 100;
        private const string CUSTOM_URL = "wp/v2/performance";

        private int GetTotalPages( string uri )
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create( uri );
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            int totalPages = (int) Math.Ceiling(
                double.Parse( response.Headers ["X-WP-TotalPages"] ) / PERFORMANCES_PER_PAGE );

            return totalPages;
        }

        // Information about performance (Main Image)

        #region Access to Main Image

        private class Media: WordPressPCL.Models.Base
        {
            [JsonProperty( "media_details", DefaultValueHandling = DefaultValueHandling.Ignore )]
            public Media_detailsItem Media_details { get; set; }
        }

        private class Media_detailsItem: WordPressPCL.Models.Base
        {
            [JsonProperty( "sizes", DefaultValueHandling = DefaultValueHandling.Ignore )]
            public SizesItem Sizes { get; set; }
        }

        private class SizesItem: WordPressPCL.Models.Base
        {
            [JsonProperty( "full", DefaultValueHandling = DefaultValueHandling.Ignore )]
            public FullItem Full { get; set; }
        }

        private class FullItem: WordPressPCL.Models.Base
        {
            [JsonProperty( "source_url", DefaultValueHandling = DefaultValueHandling.Ignore )]
            public string Source_url { get; set; }
        }

        #endregion

        // Information about performance (Schedule)

        #region Access to Schedule

        private class Performance: WordPressPCL.Models.Base
        {
            [JsonProperty( "id", DefaultValueHandling = DefaultValueHandling.Ignore )]
            public int PerformanceId { get; set; }

            [JsonProperty( "title", DefaultValueHandling = DefaultValueHandling.Ignore )]
            public RenderedItem Title { get; set; }

            [JsonProperty( "featured_media", DefaultValueHandling = DefaultValueHandling.Ignore )]
            public int Featured_media { get; set; }

            [JsonProperty( "acf", DefaultValueHandling = DefaultValueHandling.Ignore )]
            public ACF AcfInfo { get; set; }
        }

        private class ACF: WordPressPCL.Models.Base
        {
            [JsonProperty( "about_group", DefaultValueHandling = DefaultValueHandling.Ignore )]
            public AboutGroup AboutGroup { get; set; }
        }

        private class AboutGroup: WordPressPCL.Models.Base
        {
            [JsonProperty( "schedule", DefaultValueHandling = DefaultValueHandling.Ignore )]
            [DefaultValue( false )]
            public IEnumerable<Schedule> Schedule { get; set; }
        }

        private class Schedule: WordPressPCL.Models.Base
        {
            [JsonProperty( "schedule_shows", DefaultValueHandling = DefaultValueHandling.Ignore )]
            public IEnumerable<ScheduleShows> ScheduleShows { get; set; }
        }

        private class ScheduleShows: WordPressPCL.Models.Base
        {
            [JsonProperty( "schedule_day", DefaultValueHandling = DefaultValueHandling.Ignore )]
            public string scheduleDay { get; set; }

            [JsonProperty( "schedule_time", DefaultValueHandling = DefaultValueHandling.Ignore )]
            public string scheduleTime { get; set; }

            [JsonProperty( "schedule_link", DefaultValueHandling = DefaultValueHandling.Ignore )]
            public string scheduleLink { get; set; }
        }

        private class RenderedItem: WordPressPCL.Models.Base
        {
            [JsonProperty( "rendered", DefaultValueHandling = DefaultValueHandling.Ignore )]
            public string Rendered { get; set; }
        }

        #endregion

        private async Task<IEnumerable<Performance>> GetPerformances( WordPressClient client )
        {
            string uriForGettingTotalPages = $"{client.WordPressUri}{CUSTOM_URL}?per_page=1";
            int totalPages = GetTotalPages( uriForGettingTotalPages );

            List<Performance> performances = new List<Performance>();
            IEnumerable<Performance> newPerformances = null;
            string customRequest = $"wp/v2/performance?per_page=100&page=";

            for ( int i = 1; i <= totalPages; ++i )
            {
                newPerformances = await client.CustomRequest
                    .Get<IEnumerable<Performance>>( $"{customRequest}{i}" );
                performances.AddRange( newPerformances );
            }

            return newPerformances;
        }

        private static async Task<Media> GetMainImage( WordPressClient client, int featured_media )
        {
            return await client.CustomRequest.Get<Media>( $"wp/v2/media/{featured_media}" );
        }

        public IEnumerable<ScheduleDataModelBase> GetListPerformancesByDateRange( string languageCode,
            DateTime? startDate)
        {
            // No localization yet

            var performances = GetPerformances( InitializeClient() ).Result;
            List<ScheduleDataModelWp> schedule = new List<ScheduleDataModelWp>();

            foreach ( var performance in performances )
            {
                IEnumerable<Schedule> scheduleObj = performance.AcfInfo.AboutGroup.Schedule;
                if ( scheduleObj != null )
                {
                    foreach ( var scheduleList in scheduleObj )
                    {
                        var media = GetMainImage( InitializeClient(), performance.Featured_media ).Result;
                        IEnumerable<ScheduleShows> scheduleListItem = scheduleList.ScheduleShows;

                        foreach ( var scheduleItem in scheduleListItem )
                        {
                            DateTime dateOnly = DateTime.ParseExact( scheduleItem.scheduleDay, "dd/MM/yyyy", null );
                            DateTime timeOnly = Convert.ToDateTime( scheduleItem.scheduleTime );
                            DateTime beginningDate = dateOnly.Date.Add( timeOnly.TimeOfDay );

                            if ( !startDate.HasValue || beginningDate >= startDate &&
                                beginningDate <= startDate.Value.AddMonths( 1 ) )
                            {
                                schedule.Add( new ScheduleDataModelWp()
                                {
                                    PerformanceId = performance.PerformanceId,
                                    MainImage = media.Media_details.Sizes.Full.Source_url,
                                    Title = WebUtility.HtmlDecode( performance.Title.Rendered ),
                                    Beginning = beginningDate,
                                    redirectToTicket = scheduleItem.scheduleLink
                                } );
                            }
                        }
                    }
                }
            }
            schedule.Sort( ( x, y ) => x.Beginning.CompareTo( y.Beginning ) );
            return schedule;
        }
    }
}
