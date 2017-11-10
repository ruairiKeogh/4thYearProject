using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectAPI.Controllers
{
    public class FixtureController : ApiController
    {
        // GET: api/Fixture
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Fixture/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Fixture
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Fixture/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Fixture/5
        public void Delete(int id)
        {
        }
    }
}
