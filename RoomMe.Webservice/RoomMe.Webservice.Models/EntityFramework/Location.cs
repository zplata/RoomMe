using RoomMe.Webservice.Models.API;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RoomMe.Webservice.Models
{
    public class Location
    {
        [Key]
        public int LocationID { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public APILocation ToAPIModel()
        {
            return new APILocation
            {
                LocationID = this.LocationID,
                Latitude = this.Latitude,
                Longitude = this.Longitude
            };
        }
    }
}
