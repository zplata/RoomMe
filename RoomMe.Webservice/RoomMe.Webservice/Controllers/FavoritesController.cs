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
using RoomMe.Webservice.Models.EntityFramework;

namespace RoomMe.Webservice.Controllers
{
    public class FavoritesController : ApiController
    {
        private RoomMeWebserviceContext db = new RoomMeWebserviceContext();

        // GET: api/Favorites
        public IQueryable<Favorites> GetFavorites()
        {
            return db.Favorites;
        }

        // GET: api/Favorites/5
        [ResponseType(typeof(Favorites))]
        public async Task<IHttpActionResult> GetFavorites(int id)
        {
            Favorites favorites = await db.Favorites.FindAsync(id);
            if (favorites == null)
            {
                return NotFound();
            }

            return Ok(favorites);
        }

        // PUT: api/Favorites/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFavorites(int id, Favorites favorites)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != favorites.FavoritesID)
            {
                return BadRequest();
            }

            db.Entry(favorites).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoritesExists(id))
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

        // POST: api/Favorites
        [ResponseType(typeof(Favorites))]
        public async Task<IHttpActionResult> PostFavorites(Favorites favorites)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Favorites.Add(favorites);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = favorites.FavoritesID }, favorites);
        }

        // DELETE: api/Favorites/5
        [ResponseType(typeof(Favorites))]
        public async Task<IHttpActionResult> DeleteFavorites(int id)
        {
            Favorites favorites = await db.Favorites.FindAsync(id);
            if (favorites == null)
            {
                return NotFound();
            }

            db.Favorites.Remove(favorites);
            await db.SaveChangesAsync();

            return Ok(favorites);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FavoritesExists(int id)
        {
            return db.Favorites.Count(e => e.FavoritesID == id) > 0;
        }
    }
}