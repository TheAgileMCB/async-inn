using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.API.Models
{
    public class CreateHotelRoom
    {
        public int Number { get; set; }
        public decimal Rate { get; set; }
        public int RoomID {get; set;}
    }
}
