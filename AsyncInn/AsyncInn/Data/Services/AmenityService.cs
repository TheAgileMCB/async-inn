using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data.Services
{
    public class AmenityService : IAmenityService
    {
        private HotelDbContext _context;

        public AmenityService(HotelDbContext context)
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
            

        }

        public async Task<bool> UpdateAmenity(int ID, Amenity amenity)
        {
            throw new NotImplementedException();
        }
    }
}
