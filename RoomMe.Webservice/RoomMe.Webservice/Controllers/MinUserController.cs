using RoomMe.Webservice.Algorithm;
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
    [RoutePrefix("api/minuser")]
    public class MinUserController : ApiController
    {

        private RoomMeWebserviceContext db = new RoomMeWebserviceContext();

        // GET api/minUser
        public IEnumerable<APIUser> Get()
        {
            var models = db.Users;

            var minModels = new List<APIUser>();

            foreach (var model in models)
            {
                minModels.Add(model.ToAPIModel());
            }

            return minModels;
        }

        [Route("compatible")]
        public async Task<HttpResponseMessage> Compatible([FromUri] int userID)
        {
            var context = new RoomMeWebserviceContext();

            User user = await context.Users.FindAsync(userID);

            if(user == null)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, false);
            }

            Status correspondingStatus = Status.NeedsRoommateOnly;

            switch(user.Status)
            {
                case Status.NeedsRoommateOnly:
                    correspondingStatus = Status.NeedsRoommateOnly;
                    break;
                case Status.HasVacancy:
                    correspondingStatus = Status.NeedsHousingAndRoommate;
                    break;
                case Status.NeedsHousingAndRoommate:
                    correspondingStatus = Status.HasVacancy;
                    break;
                case Status.Inactive:
                    correspondingStatus = Status.Inactive;
                    break;
            }

            List<User> logicalUsers = new List<User>();

            if(correspondingStatus != Status.Inactive)
            {
                logicalUsers = context.Users.Where(x => x.Status == correspondingStatus).ToList();
            }
            else
            {
                logicalUsers = context.Users.Where(x => x.Status != Status.Inactive).ToList();
            }

            logicalUsers.Remove(user);

            MatchService ms = new MatchService();
            List<int> matchScores = new List<int>();
            List<APIUser> logicalMinUsers = new List<APIUser>();

            foreach(var u in logicalUsers)
            {
                logicalMinUsers.Add(u.ToAPIModel());
                matchScores.Add(ms.GenerateMatchScoreByStatus(user, u));
            }

            var response = new List<object> { logicalMinUsers, matchScores};

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        // GET api/minUser/5
        public async Task<IHttpActionResult> Get(int id)
        {
            User model = await db.Users.FindAsync(id);
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

            var results = context.Users.Where(x => x.Name == name).ToList();

            var apiresults = new List<APIUser>();

            foreach (var car in results)
            {
                apiresults.Add(car.ToAPIModel());
            }

            return Request.CreateResponse(HttpStatusCode.OK, apiresults);
        }

        [Route("byage")]
        public async Task<HttpResponseMessage> GetByAge([FromUri] int age)
        {
            var context = new RoomMeWebserviceContext();

            var results = context.Users.Where(x => x.Age == age).ToList();

            var apiresults = new List<APIUser>();

            foreach (var car in results)
            {
                apiresults.Add(car.ToAPIModel());
            }

            return Request.CreateResponse(HttpStatusCode.OK, apiresults);
        }

        [Route("byemail")]
        public async Task<HttpResponseMessage> GetByEmail([FromUri] string email)
        {
            var context = new RoomMeWebserviceContext();

            var results = context.Users.Where(x => x.Email == email).ToList();

            var apiresults = new List<APIUser>();

            foreach (var car in results)
            {
                apiresults.Add(car.ToAPIModel());
            }

            return Request.CreateResponse(HttpStatusCode.OK, apiresults);
        }

        [Route("byphone")]
        public async Task<HttpResponseMessage> GetByPhone([FromUri] string phone)
        {
            var context = new RoomMeWebserviceContext();

            var results = context.Users.Where(x => x.PhoneNumber == phone).ToList();

            var apiresults = new List<APIUser>();

            foreach (var car in results)
            {
                apiresults.Add(car.ToAPIModel());
            }

            return Request.CreateResponse(HttpStatusCode.OK, apiresults);
        }
    }
}
