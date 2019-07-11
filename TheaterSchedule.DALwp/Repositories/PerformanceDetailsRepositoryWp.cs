using Newtonsoft.Json;
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
using WordPressPCL;

namespace TheaterSchedule.DALwp.Repositories
{
    public class PerformanceDetailsRepositoryWp : Repository, IPerformanceDetailsRepository
    {
       // Information about performance(Title, Description, Min-Max Price, Gallery of images, Duration, Min age)
        #region Access to json without Main image
        private class Performance : WordPressPCL.Models.Base
        {
            [JsonProperty("title", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public RenderedItem Title { get; set; }

            [JsonProperty("content", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public RenderedItem Content { get; set; }

            [JsonProperty("featured_media", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public int Featured_media { get; set; }

            [JsonProperty("acf", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public ACF AcfInfo { get; set; }
        }

        private class RenderedItem : WordPressPCL.Models.Base
        {
            [JsonProperty("rendered", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public string Rendered { get; set; }
        }

        private class ACF : WordPressPCL.Models.Base
        {
            [JsonProperty("about_group", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public AboutGroup AboutGroup { get; set; }
        }

        private class AboutGroup : WordPressPCL.Models.Base
        {
            [JsonProperty("age", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public int Age { get; set; }

            [JsonProperty("price", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public string Price { get; set; }

            [JsonProperty("duration", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public int Duration { get; set; }

            [JsonProperty("gallery", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public IEnumerable<GalleryOfImages> Gallery { get; set; }
        }

        private class GalleryOfImages : WordPressPCL.Models.Base
        {
            [JsonProperty("sizes", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public LargeItem Sizes { get; set; }
        }

        private class LargeItem : WordPressPCL.Models.Base
        {
            [JsonProperty("large", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public string Large { get; set; }
        }
        #endregion

        //Information about performance(Main Image)
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

        private static async Task<Performance> GetPerformance(WordPressClient client, int perforamanceId)
        {
            return await client.CustomRequest.Get<Performance>($"wp/v2/performance/{perforamanceId}");
        }

        private static async Task<Media> GetMainImage(WordPressClient client, int featured_media)
        {
            return await client.CustomRequest.Get<Media>($"wp/v2/media/{featured_media}");
        }

        public PerformanceDetailsDataModelBase GetInformationAboutPerformance(string phoneId, string languageCode, int perforamanceId)
        {
            var performance = GetPerformance(InitializeClient(), perforamanceId).Result;
            var media = GetMainImage(InitializeClient(), performance.Featured_media).Result;

            var galleryImage = (from image in performance.AcfInfo.AboutGroup.Gallery
                                select image.Sizes.Large).ToList();


            string description = Regex.Replace(performance.Content.Rendered, @"(</p>)", "\n");
            description = Regex.Replace(description, @"(<.*?>)", string.Empty);
            description = WebUtility.HtmlDecode(description);
            description = description.Trim();

            string title = WebUtility.HtmlDecode(performance.Title.Rendered);

            var performanceDetailsDataModelWp = new PerformanceDetailsDataModelWp
            {
                Title = title,
                Description = description,
                MainImage = media.Media_details.Sizes.Full.Source_url,
                GalleryImage = galleryImage,
                MinimumAge = performance.AcfInfo.AboutGroup.Age,
                Duration = performance.AcfInfo.AboutGroup.Duration,
            };

             if (performance.AcfInfo.AboutGroup.Price.Contains('-'))
            {
                string[] Prices = (performance.AcfInfo.AboutGroup.Price).Split('-');
     
                performanceDetailsDataModelWp.MinPrice = Convert.ToInt32(Prices[0]);
                performanceDetailsDataModelWp.MaxPrice = Convert.ToInt32(Prices[1]);
            }
            else{               
                performanceDetailsDataModelWp.MinPrice = Convert.ToInt32(performance.AcfInfo.AboutGroup.Price);
                performanceDetailsDataModelWp.MaxPrice = Convert.ToInt32(performance.AcfInfo.AboutGroup.Price);
            }
            return performanceDetailsDataModelWp;
        }
    }
}