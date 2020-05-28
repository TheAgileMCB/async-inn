using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Api
{
    public class RoomDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public RoomLayout Layout { get; set; }

        public RoomAmenity Amenity { get; set; }
    }
}
