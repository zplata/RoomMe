using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoomMe.Webservice.Models
{
    public class Preferences
    {
        public Gender? Gender { get; set; }
        public int? Age { get; set; }
        public double? UpperPriceLimit { get; set; }
        public double? LowerPriceLimit { get; set; }
        public virtual List<Tag> Tags { get; set; }
        public virtual Location Location { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}
