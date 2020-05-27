using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data.Services
{
    public class HotelService : IHotelService
    {
        private HotelDbContext _context;

        public HotelService(HotelDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Hotel>> GetAllHotels()
        {
            return await _context.Hotel.ToListAsync();

        }
        public async Task<Hotel> GetOneHotel(int ID)
        {
            return await _context.Hotel.FindAsync(ID);

        }

        public async Task<bool> UpdateHotel(int ID, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(ID))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<Hotel> AddHotel(Hotel hotel)
        {
            _context.Hotel.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task<Hotel> DeleteHotel(int ID)
        {
            var hotel = await _context.Hotel.FindAsync(ID);
            if (hotel == null)
            {
                return null;
            }

            _context.Hotel.Remove(hotel);
            await _context.SaveChangesAsync();

            return hotel;
        }
        private bool HotelExists(int ID)
        {
            return _context.Hotel.Any(e => e.ID == ID);
        }


    }
}
