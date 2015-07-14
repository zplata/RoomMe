using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoomMe.Webservice.Models
{
    public class Tag
    {
        public int TagID { get; set; }
        public string Name { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
