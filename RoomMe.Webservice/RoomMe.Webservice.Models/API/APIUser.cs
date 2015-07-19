using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMe.Webservice.Models.API
{
    public class APIUser
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Status Status { get; set; }
        public double? HousingPrice { get; set; }
        public string Bio { get; set; }
        public List<int> FavoritedUserIDs { get; set; }

        public string AuthToken { get; set; }
    }
}
