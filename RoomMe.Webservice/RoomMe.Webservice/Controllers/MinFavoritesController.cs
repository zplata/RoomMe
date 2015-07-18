using RoomMe.Webservice.Models;
using RoomMe.Webservice.Models.API;
using RoomMe.Webservice.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RoomMe.Webservice.Controllers
{
    public class MinFavoritesController : ApiController
    {
        private RoomMeWebserviceContext db = new RoomMeWebserviceContext();

        // GET api/minFavorites
        public IQueryable<APIFavorites> Get()
        {
            var Favoritess = db.Favorites;

            var minFavoritess = new List<APIFavorites>();

            foreach (var Favorites in Favoritess)
            {
                minFavoritess.Add(Favorites.ToAPIModel());
            }

            return minFavoritess as IQueryable<APIFavorites>;
        }

        // GET api/minFavorites/5
        public async Task<IHttpActionResult> Get(int id)
        {
            Favorites Favorites = await db.Favorites.FindAsync(id);
            if (Favorites == null)
            {
                return NotFound();
            }

            return Ok(Favorites.ToAPIModel());
        }
    }
}
