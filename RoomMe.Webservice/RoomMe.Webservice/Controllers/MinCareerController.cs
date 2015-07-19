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
    public class MinCareerController : ApiController
    {

        private RoomMeWebserviceContext db = new RoomMeWebserviceContext();

        // GET api/mincareer
        public IEnumerable<APICareer> Get()
        {
            var careers = db.Careers;

            var minCareers = new List<APICareer>();

            foreach(var career in careers)
            {
                minCareers.Add(career.ToAPIModel());
            }

            return minCareers;
        }

        // GET api/mincareer/5
        public async Task<IHttpActionResult> Get(int id)
        {
            Career career = await db.Careers.FindAsync(id);
            if (career == null)
            {
                return NotFound();
            }

            return Ok(career.ToAPIModel());
        }
    }
}
