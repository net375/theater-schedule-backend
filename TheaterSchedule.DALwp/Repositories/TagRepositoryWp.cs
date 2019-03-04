using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.DAL.Interfaces;
using System.Threading.Tasks;
using WordPressPCL;
using WordPressPCL.Models;
using TheaterSchedule.DAL.Models;
using Newtonsoft.Json;

namespace TheaterSchedule.DALwp.Repositories
{


    public class TagRepositoryWp : Repository, ITagRepository
    {
        private class TagsItem : WordPressPCL.Models.Base
        {
            [JsonProperty("tags", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public IEnumerable<int> Tags { get; set; }
        }
        private async Task<TagsItem> GetTags( int perforamanceid )
        {
            return await InitializeClient().CustomRequest.Get<TagsItem>($"wp/v2/performance/{perforamanceid}");
        }
        public IEnumerable<string> GetTagByPerformanceId( int performanceId )
        {
            var tagsId = GetTags(performanceId).Result.Tags;
            List<string> tags = new List<string>();

            foreach ( var tagId in tagsId )
            {
                tags.Add(InitializeClient().Tags.GetByID(tagId).Result.Name);
            }
            return tags;
        }
    }
}