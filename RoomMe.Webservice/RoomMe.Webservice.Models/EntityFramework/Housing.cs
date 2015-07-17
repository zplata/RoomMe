using RoomMe.Webservice.Models.API;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMe.Webservice.Models
{
    public class Housing
    {
        [Key]
        public int HousingID { get; set; }
        public string Name { get; set; }
        public virtual List<User> Residents { get; set; }
        public int LocationID { get; set; }
        public virtual Location Location { get; set; }
        public string Address { get; set; }

        public APIHousing ToAPIModel()
        {
            return new APIHousing
            {
                HousingID = this.HousingID,
                Name = this.Name,
                Address = this.Address
            };
        }
    }
}
