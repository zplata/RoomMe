using RoomMe.Webservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoomMe.Webservice.DataAccess.DAO
{
    public class HousingDAO
    {
        private RoomMeWebserviceContext _context = null;

        public HousingDAO(RoomMeWebserviceContext context)
        {
            _context = context;
        }

        public Housing GetHousingByID(int housingID)
        {
            using(var db = new RoomMeWebserviceContext())
            {
                var housing = db.Housings.Find(housingID);
                return housing;
            }
        }

        public Housing GetHousingByUserID(int userID)
        {
            using(var db = new RoomMeWebserviceContext())
            {
                var user = db.Users.Find(userID);
                if(user != null)
                {
                    db.Users.Attach(user);
                    var result = user.Housing;
                }
                return null;
            }
        }

        public List<Housing> GetHousingsByPreferenceID(int preferenceID)
        {
            using(var db = new RoomMeWebserviceContext())
            {
                var pref = db.Housing.Find(preferenceID);
                if(pref != null)
                {
                    return pref.Housings.ToList();
                }
                return null;
            }
        }
    }
}