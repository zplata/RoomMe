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
    public class MinHousingController : ApiController
    {

        private RoomMeWebserviceContext db = new RoomMeWebserviceContext();

        // GET api/minhousing
        public IQueryable<APIHousing> Get()
        {
            var models = db.Housings;

            var minModels = new List<APIHousing>();

            foreach (var model in models)
            {
                minModels.Add(model.ToAPIModel());
            }

            return minModels as IQueryable<APIHousing>;
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
    }
}
