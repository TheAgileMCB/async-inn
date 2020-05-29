using AsyncInn.Models;
using AsyncInn.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data.Services
{
    public interface IHotelRepository
    {
        Task<IEnumerable<HotelDTO>> GetAllHotels();

       Task<HotelDTO> GetOneHotel(int ID);

        Task<bool> UpdateHotel(int ID, Hotel hotel);

        Task<Hotel> AddHotel(Hotel hotel);

        Task<Hotel> DeleteHotel(int ID);

        //Task<IEnumerable<HotelRoomDTO>> GetHotelRooms(int hotelID);
    }
}
