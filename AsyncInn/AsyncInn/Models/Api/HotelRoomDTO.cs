using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Api
{
    public class HotelRoomDTO
    {
        public int HotelID { get; set; }
        public int Number { get; set; }
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }
        public Room Room { get; set; }
    }
}
