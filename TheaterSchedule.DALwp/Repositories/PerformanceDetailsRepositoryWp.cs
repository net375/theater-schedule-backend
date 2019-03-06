using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
using WordPressPCL;

namespace TheaterSchedule.DALwp.Repositories
{
    public class RenderedItem: WordPressPCL.Models.Base
    {
        [JsonProperty( "rendered", DefaultValueHandling = DefaultValueHandling.Ignore )]
        public string Rendered { get; set; }
    }

    public class AboutGroup : WordPressPCL.Models.Base
    {
    [JsonProperty("age", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int Age { get; set; }

    [JsonProperty("price", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Price { get; set; }

    [JsonProperty("duration", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int Duration { get; set; }
    }

    public class ACF : WordPressPCL.Models.Base
    {
        [JsonProperty("about_group", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public AboutGroup AboutGroup { get; set; }
    }

    public class Performance: WordPressPCL.Models.Base
    {
        [JsonProperty( "title", DefaultValueHandling = DefaultValueHandling.Ignore )]
        public RenderedItem Title { get; set; }

        [JsonProperty( "content", DefaultValueHandling = DefaultValueHandling.Ignore )]
        public RenderedItem Content { get; set; }

        [JsonProperty( "featured_media", DefaultValueHandling = DefaultValueHandling.Ignore )]
        public int Featured_media { get; set; }

        [JsonProperty("acf", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ACF AcfInfo { get; set; }


    }


    public class Media_detailsItem: WordPressPCL.Models.Base
    {
        [JsonProperty( "sizes", DefaultValueHandling = DefaultValueHandling.Ignore )]
        public SizesItem Sizes { get; set; }
    }

    public class SizesItem: WordPressPCL.Models.Base
    {
        [JsonProperty( "large", DefaultValueHandling = DefaultValueHandling.Ignore )]
        public ImageItem Large { get; set; }

        [JsonProperty( "full", DefaultValueHandling = DefaultValueHandling.Ignore )]
        public ImageItem Full { get; set; }
    }

    public class ImageItem: WordPressPCL.Models.Base
    {
        [JsonProperty( "source_url", DefaultValueHandling = DefaultValueHandling.Ignore )]
        public string Source_url { get; set; }
    }

    public class Media: WordPressPCL.Models.Base
    {
        [JsonProperty( "media_details", DefaultValueHandling = DefaultValueHandling.Ignore )]
        public Media_detailsItem Media_details { get; set; }
    }

    public class PerformanceDetailsRepositoryWp: Repository, IPerformanceDetailsRepository
    {
        public static async Task<Performance> GetPerformance( WordPressClient client, int perforamanceId )
        {
            return await client.CustomRequest.Get<Performance>( $"wp/v2/performance/{perforamanceId}" );
        }

        public static async Task<IEnumerable<Media>> GetMediaOfPerformance( WordPressClient client, int perforamanceId )
        {
            return await client.CustomRequest.Get<IEnumerable<Media>>( $"wp/v2/media?parent={perforamanceId}" );
        }

        public PerformanceDetailsDataModelBase GetInformationAboutPerformance( string phoneId, string languageCode, int perforamanceId )
        {
            var performance = GetPerformance( InitializeClient(), perforamanceId ).Result;
            var media = GetMediaOfPerformance( InitializeClient(), perforamanceId ).Result;
            var mainImage = media.First().Media_details.Sizes.Full.Source_url;
            List<string> galleryImage = new List<string>();

            foreach ( var image in media.Skip( 1 ) ) // Skip Main Image
            {
                galleryImage.Add( image.Media_details.Sizes.Large.Source_url );
            }

            string [] a = (performance.AcfInfo.AboutGroup.Price).Split('-');  // want to change DB 

            return new PerformanceDetailsDataModelWp()
            {
                Title = performance.Title.Rendered,
                Description = performance.Content.Rendered,
                MainImage = mainImage,
                GalleryImage = galleryImage,
                //TODO
                //No such fields in API : MinPrice, MaxPrice, MinimumAge, Duration. But they exist in site        
                MinimumAge = performance.AcfInfo.AboutGroup.Age,
                MinPrice = Convert.ToInt32(a [0]),
                MaxPrice = Convert.ToInt32(a [1]),
                Duration = performance.AcfInfo.AboutGroup.Duration,
            };

        }
    }
}
