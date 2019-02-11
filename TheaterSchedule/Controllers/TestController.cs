using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TheaterSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        readonly ILogger<TestController> _log;

        public TestController(ILogger<TestController> log)
        {
            _log = log;
        }
        // GET api/test
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _log.LogInformation("Hello, world!");
            return new string[] { "testValue1", "testValue2", "testValue2" };
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
