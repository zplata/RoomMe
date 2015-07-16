using RoomMe.Webservice.Models.API;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RoomMe.Webservice.Models
{
    public class Preferences
    {
        [Key]
        public int PreferencesID { get; set; }
        public Gender? Gender { get; set; }
        public int? Age { get; set; }
        public double? UpperPriceLimit { get; set; }
        public double? LowerPriceLimit { get; set; }
        public virtual List<Tag> Tags { get; set; }
        public virtual List<Location> Locations { get; set; }
        public virtual List<Housing> Housings { get; set; }

        public APIPreferences ToAPIModel()
        {
            return new APIPreferences
            {
                PreferencesID = this.PreferencesID,
                Gender = this.Gender,
                Age = this.Age,
                LowerPriceLimit = this.LowerPriceLimit,
                UpperPriceLimit = this.UpperPriceLimit
            };
        }
    }
}
