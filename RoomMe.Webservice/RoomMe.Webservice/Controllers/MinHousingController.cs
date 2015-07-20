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
    [RoutePrefix("api/minhousing")]
    public class MinHousingController : ApiController
    {

        private RoomMeWebserviceContext db = new RoomMeWebserviceContext();

        // GET api/minhousing
        public IEnumerable<APIHousing> Get()
        {
            var models = db.Housings;

            var minModels = new List<APIHousing>();

            foreach (var model in models)
            {
                minModels.Add(model.ToAPIModel());
            }

            return minModels;
        }

        // GET api/minhousing/5
        public async Task<IHttpActionResult> Get(int id)
        {
            Housing model = await db.Housings.FindAsync(id);
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

            var results = context.Housings.Where(x => x.Name == name).ToList();

            var apiresults = new List<APIHousing>();

            foreach (var car in results)
            {
                apiresults.Add(car.ToAPIModel());
            }

            return Request.CreateResponse(HttpStatusCode.OK, apiresults);
        }

        [Route("byaddress")]
        public async Task<HttpResponseMessage> GetByAddress([FromUri] string address)
        {
            var context = new RoomMeWebserviceContext();

            var results = context.Housings.Where(x => x.Address == address).ToList();

            var apiresults = new List<APIHousing>();

            foreach (var car in results)
            {
                apiresults.Add(car.ToAPIModel());
            }

            return Request.CreateResponse(HttpStatusCode.OK, apiresults);
        }

        [Route("byuser")]
        public async Task<HttpResponseMessage> GetByUser([FromUri] string userID)
        {
            var context = new RoomMeWebserviceContext();

            var user = context.Users.Find(userID);

            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, false);
            }

            var results = context.Housings.Where(x => x.Residents.Contains(user)).ToList();

            var apiresults = new List<APIHousing>();

            foreach (var car in results)
            {
                apiresults.Add(car.ToAPIModel());
            }

            return Request.CreateResponse(HttpStatusCode.OK, apiresults);
        }
    }
}
