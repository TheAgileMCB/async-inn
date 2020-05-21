using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class RoomAmenity
    {
        public int RoomID { get; set; }
        public Room Room { get; set; }
        public int AmenityID { get; set; }
        public Amenity Amenity { get; set; }
    }
}
