using RoomMe.Webservice.Models.API;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMe.Webservice.Models.EntityFramework
{
    public class Favorites
    {
        [Key]
        public int FavoritesID { get; set; }

        public virtual List<User> Users { get; set; } 

        public APIFavorites ToAPIModel()
        {
            return new APIFavorites
            {
                FavoritesID = this.FavoritesID
            };
        }
    }
}
