using System.ComponentModel.DataAnnotations;

namespace AsyncInn.Web.Models
{
    public class HotelRoomSummary
    {
        public int HotelID { get; set; }
        public int Number { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Rate { get; set; }
        [Display(Name = "Pet Friendly")]
        public bool PetFriendly { get; set; }
        [Display(Name = "Room ID")]
        public int RoomID { get; set; }
        public RoomSummary Room { get; set; }
    }
}