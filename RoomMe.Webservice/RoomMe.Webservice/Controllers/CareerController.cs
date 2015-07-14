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
    public class CareerController : ApiController
    {
        private RoomMeWebserviceContext db = new RoomMeWebserviceContext();

        // GET api/Career
        public IQueryable<Career> GetCareers()
        {
            return db.Careers;
        }

        // GET api/Career/5
        [ResponseType(typeof(Career))]
        public async Task<IHttpActionResult> GetCareer(int id)
        {
            Career career = await db.Careers.FindAsync(id);
            if (career == null)
            {
                return NotFound();
            }

            return Ok(career);
        }

        // PUT api/Career/5
        public async Task<IHttpActionResult> PutCareer(int id, Career career)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != career.CareerID)
            {
                return BadRequest();
            }

            db.Entry(career).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CareerExists(id))
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

        // POST api/Career
        [ResponseType(typeof(Career))]
        public async Task<IHttpActionResult> PostCareer(Career career)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Careers.Add(career);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = career.CareerID }, career);
        }

        // DELETE api/Career/5
        [ResponseType(typeof(Career))]
        public async Task<IHttpActionResult> DeleteCareer(int id)
        {
            Career career = await db.Careers.FindAsync(id);
            if (career == null)
            {
                return NotFound();
            }

            db.Careers.Remove(career);
            await db.SaveChangesAsync();

            return Ok(career);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CareerExists(int id)
        {
            return db.Careers.Count(e => e.CareerID == id) > 0;
        }
    }
}