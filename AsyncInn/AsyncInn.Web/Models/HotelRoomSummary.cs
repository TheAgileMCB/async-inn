namespace AsyncInn.Web.Models
{
    public class HotelRoomSummary
    {
        public int HotelID { get; set; }
        public int Number { get; set; }
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }
        public int RoomID { get; set; }
        public RoomSummary Room { get; set; }
    }
}