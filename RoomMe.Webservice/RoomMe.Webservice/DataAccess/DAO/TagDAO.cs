using RoomMe.Webservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoomMe.Webservice.DataAccess.DAO
{
    public class TagDAO
    {
        private RoomMeWebserviceContext _context = null;

        public TagDAO(RoomMeWebserviceContext context)
        {
            _context = context;
        }

        public Tag GetTagByID(int tagID)
        {
            using (var db = new RoomMeWebserviceContext())
            {
                return db.Tags.Find(tagID);
            }
        }

        public List<Tag> GetTagsByUserID(int userID)
        {
            using(var db = new RoomMeWebserviceContext())
            {
                var user = db.Users.Find(userID);
                if(user != null)
                {
                    return user.Tags;
                }
                return null;
            }
        }

        public List<Tag> GetTagsByPreferenceID(int preferenceID)
        {
            using(var db = new RoomMeWebserviceContext())
            {
                var pref = db.Preferences.Find(preferenceID);
                if(pref != null)
                {
                    return pref.Tags;
                }
                return null;
            }
        }
    }
}