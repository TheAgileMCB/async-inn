using AsyncInn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data.Services
{
    public interface IHotelService
    {
        Task<IEnumerable<Hotel>> GetAllHotels();

       Task<Hotel> GetOneHotel(int ID);

        Task<bool> UpdateHotel(int ID, Hotel hotel);

        Task<Hotel> AddHotel(Hotel hotel);

        Task<Hotel> DeleteHotel(int ID);
    }
}
