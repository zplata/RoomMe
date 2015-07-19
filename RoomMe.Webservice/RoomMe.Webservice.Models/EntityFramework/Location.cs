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
        public double Latitude { get; set; }
        public double Longitude { get; set; }

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
