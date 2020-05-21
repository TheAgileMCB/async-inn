using Microsoft.AspNetCore.Mvc.TagHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class HotelRoom
    {
        public int HotelID { get; set; }
        public int RoomID { get; set; }

        [Required]
        public int RoomNumber { get; set; }
        [Required]
        public decimal Rate { get; set; }
        [Required]
        public bool PetFriendly { get; set; }
    }
}
