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
    public class PreferencesController : ApiController
    {
        private RoomMeWebserviceContext db = new RoomMeWebserviceContext();

        // GET api/Preferences
        public IQueryable<Preferences> GetPreferences()
        {
            return db.Housing;
        }

        // GET api/Preferences/5
        [ResponseType(typeof(Preferences))]
        public async Task<IHttpActionResult> GetPreferences(int id)
        {
            Preferences preferences = await db.Housing.FindAsync(id);
            if (preferences == null)
            {
                return NotFound();
            }

            return Ok(preferences);
        }

        // PUT api/Preferences/5
        public async Task<IHttpActionResult> PutPreferences(int id, Preferences preferences)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != preferences.PreferencesID)
            {
                return BadRequest();
            }

            db.Entry(preferences).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreferencesExists(id))
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

        // POST api/Preferences
        [ResponseType(typeof(Preferences))]
        public async Task<IHttpActionResult> PostPreferences(Preferences preferences)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Housing.Add(preferences);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = preferences.PreferencesID }, preferences);
        }

        // DELETE api/Preferences/5
        [ResponseType(typeof(Preferences))]
        public async Task<IHttpActionResult> DeletePreferences(int id)
        {
            Preferences preferences = await db.Housing.FindAsync(id);
            if (preferences == null)
            {
                return NotFound();
            }

            db.Housing.Remove(preferences);
            await db.SaveChangesAsync();

            return Ok(preferences);
        }

        public async Task<HttpResponseMessage> AssociateTag(int tagID, int preferencesID)
        {
            var context = new RoomMeWebserviceContext();
            var tag = context.Tags.Find(tagID);
            var preferences = context.Housing.Find(preferencesID);

            if ((tag == null) || (preferences == null))
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Could not find preference or tag");
            }
            else
            {
                context.Housing.Attach(preferences);
                context.Tags.Attach(tag);

                preferences.Tags.Add(tag);

                context.Entry(preferences).State = EntityState.Modified;
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

        public async Task<HttpResponseMessage> AssociateLocation(int locationID, int preferencesID)
        {
            var context = new RoomMeWebserviceContext();
            var location = context.Locations.Find(locationID);
            var preferences = context.Housing.Find(preferencesID);

            if ((location == null) || (preferences == null))
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Could not find preference or tag");
            }
            else
            {
                context.Housing.Attach(preferences);
                context.Locations.Attach(location);

                preferences.Locations.Add(location);

                context.Entry(preferences).State = EntityState.Modified;
                context.Entry(location).State = EntityState.Modified;

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

        public async Task<HttpResponseMessage> AssociateHousing(int housingID, int preferencesID)
        {
            var context = new RoomMeWebserviceContext();
            var housing = context.Housings.Find(housingID);
            var preferences = context.Housing.Find(preferencesID);

            if ((housing == null) || (preferences == null))
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Could not find preference or tag");
            }
            else
            {
                context.Housing.Attach(preferences);
                context.Housings.Attach(housing);

                preferences.Housings.Add(housing);

                context.Entry(preferences).State = EntityState.Modified;
                context.Entry(housing).State = EntityState.Modified;

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

        private bool PreferencesExists(int id)
        {
            return db.Housing.Count(e => e.PreferencesID == id) > 0;
        }
    }
}