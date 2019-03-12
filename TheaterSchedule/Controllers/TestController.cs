using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TheaterSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "testValue1", "testValue2", "testValue2" };
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "testValue";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
