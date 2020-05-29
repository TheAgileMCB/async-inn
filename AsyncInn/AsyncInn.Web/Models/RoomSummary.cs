using System.Collections.Generic;

namespace AsyncInn.Web.Models
{
    public class RoomSummary
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Layout { get; set; }

        public List<AmenitySummary> Amenities { get; set; }
    }
}