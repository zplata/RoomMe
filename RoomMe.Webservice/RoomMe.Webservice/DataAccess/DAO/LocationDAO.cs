using RoomMe.Webservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoomMe.Webservice.DataAccess.DAO
{
    public class LocationDAO
    {
        private RoomMeWebserviceContext _context = null;
        public LocationDAO(RoomMeWebserviceContext context)
        {
            _context = context;
        }

        public Location GetLocationByID(int locationID)
        {
            using (var db = new RoomMeWebserviceContext())
            {
                var location = db.Locations.Find(locationID);
                return location;
            }
        }

        public List<Location> GetLocationsByPreferenceID(int preferenceID)
        {
            using (var db = new RoomMeWebserviceContext())
            {
                var pref = db.Housing.Find(preferenceID);
                if(pref != null)
                {
                    return pref.Locations;
                }
                return null;
            }
        }

        public Location GetLocationByHousingID(int housingID)
        {
            using (var db = new RoomMeWebserviceContext())
            {
                var housing = db.Housings.Find(housingID);
                if(housing != null)
                {
                    return housing.Location;
                }
                return null;
            }
        }
    }
}