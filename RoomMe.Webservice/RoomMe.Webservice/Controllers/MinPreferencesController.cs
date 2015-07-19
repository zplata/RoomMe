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
    public class MinPreferencesController : ApiController
    {

        private RoomMeWebserviceContext db = new RoomMeWebserviceContext();

        // GET api/minPreferences
        public IEnumerable<APIPreferences> Get()
        {
            var models = db.Preferences;

            var minModels = new List<APIPreferences>();

            foreach (var model in models)
            {
                minModels.Add(model.ToAPIModel());
            }

            return minModels;
        }

        // GET api/minPreferences/5
        public async Task<IHttpActionResult> Get(int id)
        {
            Preferences model = await db.Preferences.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model.ToAPIModel());
        }
    }
}
