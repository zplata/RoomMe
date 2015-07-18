using RoomMe.Webservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoomMe.Webservice.DataAccess.DAO
{
    public class UserDAO
    {
        private RoomMeWebserviceContext _context = null;
        public UserDAO(RoomMeWebserviceContext context)
        {
            _context = context;
        }

        public User GetUserbyID(int userID)
        {
            using(var db = new RoomMeWebserviceContext())
            {
                return db.Users.Find(userID);
            }
        }

        public List<User> GetUsersByTagID(int tagID)
        {
            using(var db = new RoomMeWebserviceContext())
            {
                var tag = db.Tags.Find(tagID);
                if(tag != null)
                {
                    return tag.Users;
                }
                return null;
            }
        }

        public List<User> GetUsersByTagIDs(int[] tagIDs)
        {
            var users = new List<User>();
            foreach(var id in tagIDs)
            {
                var returnedUsers = GetUsersByTagID(id);
                foreach(var user in returnedUsers)
                {
                    if(!users.Contains(user))
                    {
                        users.Add(user);
                    }
                }
            }

            return users;
        }

        public List<User> GetUsersByHousingID(int housingID)
        {
            using(var db = new RoomMeWebserviceContext())
            {
                var housing = db.Housings.Find(housingID);
                if(housing != null)
                {
                    return housing.Residents;
                }
                return null;   
            }
        }

        public List<User> GetUsersByCareerID(int careerID)
        {
            using(var db = new RoomMeWebserviceContext())
            {
                var career = db.Careers.Find(careerID);
                if(career != null)
                {
                    return career.Users;
                }
                return null;
            }
        }
    }
}