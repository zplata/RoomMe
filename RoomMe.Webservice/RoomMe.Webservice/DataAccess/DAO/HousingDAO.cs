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

        Housing GetHousingByUserID(int userID)
        {
            using(var db = new RoomMeWebserviceContext())
            {
                var user = db.Users.Find(userID);
                if(user != null)
                {
                    db.Users.Attach(user);
                    var result = db.Housings.Where(x => x.Residents.Contains(user));
                    return result.First();
                }

                return null;
                
            }
        }
    }
}