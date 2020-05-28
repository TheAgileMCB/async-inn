using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data.Services
{
    public class AmenityRepository : IAmenityService
    {
        private HotelDbContext _context;

        public AmenityRepository(HotelDbContext context)
        {
            _context = context;
        }
        public async Task<Amenity> AddAmenity(Amenity amenity)
        {
            _context.Amenity.Add(amenity);
            await _context.SaveChangesAsync();
            return amenity;
        }

        public async Task<Amenity> DeleteAmenity(int ID)
        {
            var amenity = await _context.Amenity.FindAsync(ID);
            if (amenity == null)
            {
                return null;
            }

            _context.Amenity.Remove(amenity);
            await _context.SaveChangesAsync();

            return amenity;
        }

        public async Task<IEnumerable<Amenity>> GetAllAmenities()
        {
            return await _context.Amenity.ToListAsync();
        }

        public async Task<Amenity> GetOneAmenity(int ID)
        {
            return await _context.Amenity.FindAsync(ID);
        }

        public async Task<bool> UpdateAmenity(int ID, Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmenityExists(ID))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }
        private bool AmenityExists(int ID)
        {
            return _context.Amenity.Any(e => e.ID == ID);
        }
    }
}
