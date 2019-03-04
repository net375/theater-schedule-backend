using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;

namespace TheaterSchedule.BLL.Services
{
    public class TagService: ITagService
    {
        private ITagRepository tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        public TagDTO LoadTagsById(int id)
        {
            TagDTO tagRequest = new TagDTO() { TagName = tagRepository.GetTagsByPerformanceId(id).Result };
            return tagRequest;
        }
    }
}
