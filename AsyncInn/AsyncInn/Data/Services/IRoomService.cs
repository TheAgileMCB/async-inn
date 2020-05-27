using AsyncInn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data.Services
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetAllRooms();

        Task<Room> GetOneRoom(int ID);

        Task<bool> UpdateRoom(int ID, Room room);

        Task<Room> AddRoom(Room room);

        Task<Room> DeleteRoom(int ID);
    }
}
