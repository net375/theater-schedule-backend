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

    public class Performance: WordPressPCL.Models.Base
    {
        [JsonProperty( "title", DefaultValueHandling = DefaultValueHandling.Ignore )]
        public RenderedItem Title { get; set; }

        [JsonProperty( "content", DefaultValueHandling = DefaultValueHandling.Ignore )]
        public RenderedItem Content { get; set; }

        [JsonProperty( "featured_media", DefaultValueHandling = DefaultValueHandling.Ignore )]
        public int Featured_media { get; set; }

        [JsonProperty( "tags", DefaultValueHandling = DefaultValueHandling.Ignore )]
        public IEnumerable<int> Tags { get; set; }
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

    public class PerformanceDetailsRepositoryWp: IPerformanceDetailsRepository
    {
        public static async Task<Performance> GetPerformance( int perforamanceid )
        {
            var client = new WordPressClient( "https://lvivpuppet.com/wp-json" );
            return await client.CustomRequest.Get<Performance>( $"wp/v2/performance/411" );
        }

        public static async Task<IEnumerable<Media>> GetMediaOfPerformance( int perforamanceid )
        {
            var client = new WordPressClient( "https://lvivpuppet.com/wp-json" );
            return await client.CustomRequest.Get<IEnumerable<Media>>( $"wp/v2/media?parent=411" );
        }

        public PerformanceDetailsDataModel GetInformationAboutPerformanceScreen( string phoneId, string languageCode, int id )
        {
            var performance = GetPerformance( id ).Result;
            var media = GetMediaOfPerformance( performance.Featured_media ).Result;
            var mainImage = media.First().Media_details.Sizes.Full.Source_url;
            List<string> galleryImage = new List<string>();

            foreach ( var image in media.Skip( 1 ) ) // Skip Main Image
            {
                galleryImage.Add( image.Media_details.Sizes.Large.Source_url );
            }

            return new PerformanceDetailsDataModel()
            {
                Title = performance.Title.Rendered,
                Description = performance.Content.Rendered,
                MainImageWp = mainImage,
                GalleryImageWp = galleryImage,
                Tags = performance.Tags,

            };
            //TODO
            //No such fields in API : MinPrice, MaxPrice, MinimumAge, Duration. But they exist in site        
        }
    }
}
