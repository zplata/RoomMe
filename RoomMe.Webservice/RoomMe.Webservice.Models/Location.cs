using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoomMe.Webservice.Models
{
    public class Location
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public virtual List<User> Residents { get; set; }
    }
}
