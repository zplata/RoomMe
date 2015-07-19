using RoomMe.Webservice.Algorithm;
using RoomMe.Webservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RoomMe.Webservice.Controllers
{
    [RoutePrefix("api/match")]
    public class MatchController : ApiController
    {
        // GET: api/Match
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("compatibility")]
        // GET: api/Match/5
        public async Task<HttpResponseMessage> Match([FromUri] int idA, [FromUri] int idB)
        {
            var context = new RoomMeWebserviceContext();

            MatchService ms = new MatchService();

            User a = context.Users.Find(idA);
            User b = context.Users.Find(idB);

            int score = ms.GenerateMatchScoreOfPreferences(a, b);
            return Request.CreateResponse(HttpStatusCode.OK, score);
        }



        // POST: api/Match
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Match/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Match/5
        public void Delete(int id)
        {
        }
    }
}
