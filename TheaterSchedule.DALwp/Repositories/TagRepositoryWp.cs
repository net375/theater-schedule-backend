using System.Collections.Generic;
using TheaterSchedule.DAL.Interfaces;
using System.Threading.Tasks;
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
   
        public async Task<IEnumerable<string>> GetTagsByPerformanceId(int id)
        {
            var tagsId = await InitializeClient().CustomRequest.Get<TagsItem>($"wp/v2/performance/{id}");

            List<string> tags = new List<string>();
            foreach (var tag in tagsId.Tags)
            {
                tags.Add(InitializeClient().Tags.GetByID(tag).Result.Name);
            }

            return tags;
        }
    }
}