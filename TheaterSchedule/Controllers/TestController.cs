using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TheaterSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET api/test
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "testValue1", "testValue2" };
        }

        // GET api/test/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "testValue";
        }

        // POST api/test
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/test/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/test/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
