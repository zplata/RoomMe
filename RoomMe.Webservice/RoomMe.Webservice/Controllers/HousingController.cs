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
    public class HousingController : ApiController
    {
        private RoomMeWebserviceContext db = new RoomMeWebserviceContext();

        // GET api/Housing
        public IQueryable<Housing> GetHousings()
        {
            return db.Housings;
        }

        // GET api/Housing/5
        [ResponseType(typeof(Housing))]
        public async Task<IHttpActionResult> GetHousing(int id)
        {
            Housing housing = await db.Housings.FindAsync(id);
            if (housing == null)
            {
                return NotFound();
            }

            return Ok(housing);
        }

        // PUT api/Housing/5
        public async Task<IHttpActionResult> PutHousing(int id, Housing housing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != housing.HousingID)
            {
                return BadRequest();
            }

            db.Entry(housing).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HousingExists(id))
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

        // POST api/Housing
        [ResponseType(typeof(Housing))]
        public async Task<IHttpActionResult> PostHousing(Housing housing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Housings.Add(housing);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = housing.HousingID }, housing);
        }

        // DELETE api/Housing/5
        [ResponseType(typeof(Housing))]
        public async Task<IHttpActionResult> DeleteHousing(int id)
        {
            Housing housing = await db.Housings.FindAsync(id);
            if (housing == null)
            {
                return NotFound();
            }

            db.Housings.Remove(housing);
            await db.SaveChangesAsync();

            return Ok(housing);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HousingExists(int id)
        {
            return db.Housings.Count(e => e.HousingID == id) > 0;
        }
    }
}