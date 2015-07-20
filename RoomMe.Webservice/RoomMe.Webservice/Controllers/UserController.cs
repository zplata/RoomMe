using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using RoomMe.Webservice.Models;

namespace RoomMe.Webservice.Controllers
{
    public class UserController : ApiController
    {
        private RoomMeWebserviceContext db = new RoomMeWebserviceContext();

        // GET api/User
        public IEnumerable<User> GetUsers()
        {

            var result = db.Users.ToList();

            return result;
        }

        // GET api/User/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT api/User/5
        public async Task<IHttpActionResult> PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserID)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/User
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = user.UserID }, user);
        }

        // DELETE api/User/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> DeleteUser(int id)
        {
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            await db.SaveChangesAsync();

            return Ok(user);
        }

        public async Task<HttpResponseMessage> AssociateCareer([FromUri] int careerID, [FromUri] int userID)
        {
            var context = new RoomMeWebserviceContext();
            var career = context.Careers.Find(careerID);
            var user = context.Users.Find(userID);

            if((career == null) || (user == null))
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Could not find user or career");
            }
            else
            {
                context.Users.Attach(user);
                context.Careers.Attach(career);

                user.Job = career;

                context.Entry(user).State = EntityState.Modified;

                try
                {
                    await context.SaveChangesAsync();
                    return Request.CreateResponse(HttpStatusCode.OK, true);
                }
                catch(Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to save.");
                }
                
            }

        }

        public async Task<HttpResponseMessage> AssociateHousing([FromUri] int housingID, [FromUri] int userID)
        {
            var context = new RoomMeWebserviceContext();
            var housing = context.Housings.Find(housingID);
            var user = context.Users.Find(userID);

            if ((housing == null) || (user == null))
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Could not find user or housing");
            }
            else
            {
                context.Users.Attach(user);
                context.Housings.Attach(housing);

                user.Housing = housing;

                context.Entry(user).State = EntityState.Modified;
                try
                {
                    await context.SaveChangesAsync();
                    return Request.CreateResponse(HttpStatusCode.OK, true);
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to save.");
                }

            }
        }

        public async Task<HttpResponseMessage> AssociateTag([FromUri] int tagID, [FromUri] int userID)
        {
            var context = new RoomMeWebserviceContext();
            var tag = context.Tags.Find(tagID);
            var user = context.Users.Find(userID);

            if ((tag == null) || (user == null))
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Could not find user or tag");
            }
            else
            {
                context.Users.Attach(user);
                context.Tags.Attach(tag);

                user.Tags.Add(tag);

                context.Entry(user).State = EntityState.Modified;
                context.Entry(tag).State = EntityState.Modified;

                try
                {
                    await context.SaveChangesAsync();
                    return Request.CreateResponse(HttpStatusCode.OK, true);
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to save.");
                }

            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.UserID == id) > 0;
        }
    }
}