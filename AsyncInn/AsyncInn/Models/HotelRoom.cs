using Microsoft.AspNetCore.Mvc.TagHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class HotelRoom
    {
        public int HotelID { get; set; }
        
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }

        [Required]
        public int Number { get; set; }
        [Required]
        [Column (TypeName = "money")]
        public decimal Rate { get; set; }
        [Required]
        public bool PetFriendly { get; set; }
    }
}
