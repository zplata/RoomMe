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
            return db.Preferences;
        }

        // GET api/Preferences/5
        [ResponseType(typeof(Preferences))]
        public async Task<IHttpActionResult> GetPreferences(int id)
        {
            Preferences preferences = await db.Preferences.FindAsync(id);
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

            db.Preferences.Add(preferences);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = preferences.PreferencesID }, preferences);
        }

        // DELETE api/Preferences/5
        [ResponseType(typeof(Preferences))]
        public async Task<IHttpActionResult> DeletePreferences(int id)
        {
            Preferences preferences = await db.Preferences.FindAsync(id);
            if (preferences == null)
            {
                return NotFound();
            }

            db.Preferences.Remove(preferences);
            await db.SaveChangesAsync();

            return Ok(preferences);
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
            return db.Preferences.Count(e => e.PreferencesID == id) > 0;
        }
    }
}