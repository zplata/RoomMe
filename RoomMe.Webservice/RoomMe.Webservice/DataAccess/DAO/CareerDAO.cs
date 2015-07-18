﻿using RoomMe.Webservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoomMe.Webservice.DataAccess.DAO
{
    public class CareerDAO
    {
        private RoomMeWebserviceContext _context = null;
        public CareerDAO(RoomMeWebserviceContext context)
        {
            _context = context;
        }

        public Career GetByUserID(int userID)
        {
            using( var db = new RoomMeWebserviceContext())
            {
                User user = _context.Users.Find(userID);
                if (user != null)
                {
                    db.Users.Attach(user);
                    return user.Job;
                }
                return null;
            }
        }
    }
}