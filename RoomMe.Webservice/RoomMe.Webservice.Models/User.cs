using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMe.Webservice.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int CareerID { get; set; }
        public virtual Career Job { get; set; }
        public int HousingLocationID { get; set; }
        public virtual Location HousingLocation { get; set; }
        public Status Status { get; set; }
        public virtual List<Tag> Tags { get; set; }
        public bool IsActive { get; set; }
        public int PreferencesID { get; set; }
        public virtual Preferences Preferences { get; set; } // hmmm maybe a list of preferences using enum/value structure...?
        public virtual List<User> Favorites { get; set; }

        // todo: matches and suggestions. Suggestions shouldn't be stored with the user because it stores state and could be stale.
    }
}
