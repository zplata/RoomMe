using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMe.Webservice.Models.API
{
    public class APIPreferences
    {
        public int PreferencesID { get; set; }
        public Gender? Gender { get; set; }
        public int? Age { get; set; }
        public double? UpperPriceLimit { get; set; }
        public double? LowerPriceLimit { get; set; }
    }
}
