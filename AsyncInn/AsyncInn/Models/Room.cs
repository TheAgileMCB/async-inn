using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Room
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public RoomLayout Layout { get; set; }

        public RoomAmenity Amenity { get; set; }
    }

    public enum RoomLayout
    {
        OneBedroom,
        Studio,
        TwoBedroom,
        Suite,
        Villa,
        SeaSide,
        MountainView,
        PrivateIsland
    }
}

