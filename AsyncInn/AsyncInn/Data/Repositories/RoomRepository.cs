using AsyncInn.Models;
using AsyncInn.Models.Api;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
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

        public async Task<RoomDTO> GetOneRoom(int ID)
        {
            var room = await _context.Room
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
                .FirstOrDefaultAsync(hotel => hotel.ID == ID);

            return room;
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

        public async Task AddAmenityToRoom(int roomID, int amenityID)
        {
            var roomAmenity = new RoomAmenity
            {
                AmenityID = amenityID,
                RoomID = roomID
            };
            _context.RoomAmenity.Add(roomAmenity);
                await _context.SaveChangesAsync();
        }

        public async Task RemoveAmenityFromRoom(int roomID, int amenityID)
        {
            var roomAmenity = await _context.RoomAmenity
                .Where(ra => ra.AmenityID == amenityID)
                .Where(ra => ra.RoomID == roomID)
                .FirstOrDefaultAsync();

            if (roomAmenity != null)
            {
                _context.RoomAmenity.Remove(roomAmenity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
