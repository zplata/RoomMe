using RoomMe.Webservice.Models.API;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RoomMe.Webservice.Models
{
    public class Career
    {
        [Key]
        public int CareerID { get; set; }
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public virtual List<User> Users { get; set; }

        public APICareer ToAPIModel()
        {
            return new APICareer
            {
                CareerID = this.CareerID,
                Company = this.Company,
                JobTitle = this.JobTitle
            };
        }
    }
}
