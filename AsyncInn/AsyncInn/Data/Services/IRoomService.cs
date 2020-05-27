using AsyncInn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data.Services
{
    interface IRoomService
    {
        Task<IEnumerable<Room>> GetAllHotels();

        Task<Room> GetOneHotel(int ID);

        Task<bool> UpdateHotel(int ID, Room room);

        Task<Room> AddHotel(Room room);

        Task<Room> DeleteHotel(int ID);
    }
}
