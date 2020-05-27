using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data.Services
{
    public class RoomService : IRoomService
    {
        private HotelDbContext _context;

        public RoomService(HotelDbContext context)
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

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            return await _context.Room.ToListAsync();
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
    }
}
