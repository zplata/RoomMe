using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoomMe.Webservice.Models
{
    public enum Status
    {
        HasVacancy = 0,
        NeedsHousingAndRoommate,
        NeedsRoommateOnly,
        Inactive
    }
}
