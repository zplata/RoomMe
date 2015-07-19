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
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {

        private RoomMeWebserviceContext db = new RoomMeWebserviceContext();

        // GET: api/Account
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Account/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("register")]
        // POST: api/Account
        public async Task<IHttpActionResult> Register([FromBody] string email, [FromBody] string name, [FromBody] int age, [FromBody] string bio, [FromBody] int gender, [FromBody] string phone, [FromBody] string authToken)
        {
            User newUser = new User()
            {
                Email = email,
                Name = name,
                Age = age,
                Bio = bio,
                Gender = (Gender) gender,
                PhoneNumber = phone,
                Status = Status.NeedsHousingAndRoommate,
                AuthToken = authToken
            };

            db.Users.Add(newUser);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = newUser.UserID }, newUser.ToAPIModel());

        }

        // POST: api/Account
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Account/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Account/5
        public void Delete(int id)
        {
        }
    }
}
