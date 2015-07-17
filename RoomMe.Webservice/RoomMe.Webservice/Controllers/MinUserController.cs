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
    public class MinUserController : ApiController
    {

        private RoomMeWebserviceContext db = new RoomMeWebserviceContext();

        // GET api/minUser
        public IQueryable<APIUser> Get()
        {
            var models = db.Users;

            var minModels = new List<APIUser>();

            foreach (var model in models)
            {
                minModels.Add(model.ToAPIModel());
            }

            return minModels as IQueryable<APIUser>;
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
    }
}
