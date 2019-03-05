using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheaterSchedule.BLL.Services;
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
        // GET: api/Tag/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(tagService.LoadTagsById(id));
        }
    }
}
