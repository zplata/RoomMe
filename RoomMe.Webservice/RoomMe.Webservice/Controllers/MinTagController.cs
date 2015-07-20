using Newtonsoft.Json.Linq;
using RoomMe.Webservice.Models;
using RoomMe.Webservice.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RoomMe.Webservice.Controllers
{
    [RoutePrefix("api/mintag")]
    public class MinTagController : ApiController
    {

        private RoomMeWebserviceContext db = new RoomMeWebserviceContext();

        // GET api/minTag
        public IEnumerable<APITag> Get()
        {
            var models = db.Tags;

            var minModels = new List<APITag>();

            foreach (var model in models)
            {
                minModels.Add(model.ToAPIModel());
            }

            return minModels;
        }

        // GET api/minTag/5
        public async Task<IHttpActionResult> Get(int id)
        {
            Tag model = await db.Tags.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model.ToAPIModel());
        }

        [Route("byname")]
        public async Task<HttpResponseMessage> GetByName([FromUri] string name)
        {
            var context = new RoomMeWebserviceContext();

            var results = context.Tags.Where(x => x.Name == name).ToList();

            var apiresults = new List<APITag>();

            foreach (var car in results)
            {
                apiresults.Add(car.ToAPIModel());
            }

            return Request.CreateResponse(HttpStatusCode.OK, apiresults);
        }
    }
}
