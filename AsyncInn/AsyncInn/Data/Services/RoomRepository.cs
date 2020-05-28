using AsyncInn.Models;
using AsyncInn.Models.Api;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data.Services
{
    public class RoomRepository : IRoomRepository
    {
        private HotelDbContext _context;

        public RoomRepository(HotelDbContext context)
        {
            _context = context;
        }
        public async Task<Room> AddRoom(Room room)
        {
            _context.Room.Add(room);
            await _context.SaveChangesAsync();
            return room;

        }

        public async Task<Room> DeleteRoom(int ID)
        {
            var room = await _context.Room.FindAsync(ID);
            if (room == null)
            {
                return null;
            }

            _context.Room.Remove(room);
            await _context.SaveChangesAsync();

            return room;
        }

        public async Task<IEnumerable<RoomDTO>> GetAllRooms()
        {
            var rooms = await _context.Room
                .Select(room => new RoomDTO
                {
                    ID = room.ID,
                    Name = room.Name,
                    Layout = room.Layout.ToString(),

                    Amenities = room.Amenities
                            .Select(a => new AmenityDTO
                            {
                                ID = a.ID,
                                Name = a.Name
                            })
                            .ToList()
                })
                .ToListAsync();

            return rooms;
        }

        public async Task<Room> GetOneRoom(int ID)
        {
            return await _context.Room.FindAsync(ID);
        }

        public async Task<bool> UpdateRoom(int ID, Room room)
        {
            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(ID))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool RoomExists(int ID)
        {
            return _context.Room.Any(e => e.ID == ID);
        }

        internal static Task AddRoomAmenity(int roomID, object amenityID)
        {
            throw new NotImplementedException();
        }

        internal static Task RemoveRoomAmenity(int roomID, object amenityID)
        {
            throw new NotImplementedException();
        }
    }
}
