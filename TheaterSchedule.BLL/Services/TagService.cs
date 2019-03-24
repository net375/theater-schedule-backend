using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace TheaterSchedule.BLL.Services
{
    public class TagService: ITagService
    {
        private ITagRepository tagRepository;
        private IMemoryCache memoryCache;
        public Tag tagRequest;


        public TagService(ITagRepository tagRepository, IMemoryCache memoryCache)
        {
            this.tagRepository = tagRepository;
            this.memoryCache = memoryCache;
        }

        public Tag LoadTagsById(int id)
        {
            string memoryCacheKey = "Tag_"+id.ToString();
            if(!memoryCache.TryGetValue(memoryCache,out tagRequest))
            {
                tagRequest = new Tag()
                {
                    HashTag = tagRepository.GetTagsByPerformanceId(id).Result
                };
                memoryCache.Set(memoryCacheKey, tagRequest);
            }
            return tagRequest;
        }
    }
}
