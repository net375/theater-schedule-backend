using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.BLL.Interfaces;

namespace TheaterSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private ITagService tagService;
        public TagController(ITagService tagService)
        {
            this.tagService = tagService;
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(tagService.LoadTagsById(id));
        }
    }
}
