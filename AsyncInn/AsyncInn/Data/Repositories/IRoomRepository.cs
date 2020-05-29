using AsyncInn.Models;
using AsyncInn.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data.Services
{
    public interface IRoomRepository
    {
        Task<IEnumerable<RoomDTO>> GetAllRooms();

        Task<RoomDTO> GetOneRoom(int ID);

        Task<bool> UpdateRoom(int ID, Room room);

        Task<Room> AddRoom(Room room);

        Task<Room> DeleteRoom(int ID);
        Task AddAmenityToRoom(int roomID, int amenityID);

        Task RemoveAmenityFromRoom(int roomID, int amenityID);

    }
}
