using AsyncInn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data.Services
{
    public interface IHotelService
    {
        IEnumerable<Hotel> GetAllHotels();

        Hotel GetOneHotel(int ID);

        bool UpdateHotel(int ID);

        Hotel AddHotel(Hotel hotel);

        Hotel DeleteHotel(int ID);
    }
}
