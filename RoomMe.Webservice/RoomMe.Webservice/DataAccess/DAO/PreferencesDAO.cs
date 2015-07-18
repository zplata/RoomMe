using RoomMe.Webservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoomMe.Webservice.DataAccess.DAO
{
    public class PreferencesDAO
    {
        private RoomMeWebserviceContext _context = null;
        public PreferencesDAO(RoomMeWebserviceContext context)
        {
            _context = context;
        }

        public Preferences GetPreferencesByUserID(int userID)
        {
            using(var db = new RoomMeWebserviceContext())
            {
                var user = db.Users.Find(userID);
                if(user != null)
                {
                    return user.Preferences;
                }
                return null;
            }
        }
    }
}