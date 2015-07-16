using RoomMe.Webservice.Models.API;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RoomMe.Webservice.Models
{
    public class Tag
    {
        [Key]
        public int TagID { get; set; }
        public string Name { get; set; }
        public virtual List<User> Users { get; set; }

        public APITag ToModelAPI()
        {
            return new APITag
            {
                TagID = this.TagID,
                Name = this.Name
            };
        }
    }
}
