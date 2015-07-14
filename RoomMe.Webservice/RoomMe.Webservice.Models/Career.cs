using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoomMe.Webservice.Models
{
    public class Career
    {
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
