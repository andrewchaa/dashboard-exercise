using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Dashboard.App.Board.Controllers
{
    public class SamplesController : ApiController
    {
        // GET: api/Samples
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Samples/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Samples
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Samples/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Samples/5
        public void Delete(int id)
        {
        }
    }
}
