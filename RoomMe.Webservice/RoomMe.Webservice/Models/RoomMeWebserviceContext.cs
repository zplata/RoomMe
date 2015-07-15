using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RoomMe.Webservice.Models
{
    public class RoomMeWebserviceContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public RoomMeWebserviceContext() : base("name=RoomMeWebserviceContext")
        {
        }

        public System.Data.Entity.DbSet<RoomMe.Webservice.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<RoomMe.Webservice.Models.Career> Careers { get; set; }

        public System.Data.Entity.DbSet<RoomMe.Webservice.Models.Preferences> Preferences { get; set; }

        public System.Data.Entity.DbSet<RoomMe.Webservice.Models.Location> Locations { get; set; }

        public System.Data.Entity.DbSet<RoomMe.Webservice.Models.Tag> Tags { get; set; }
    
    }
}
