using AsyncInn.Models;
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
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Amenity>> GetAllAmenities()
        {
            throw new NotImplementedException();
        }

        public async Task<Amenity> GetOneAmenity(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAmenity(int ID, Amenity amenity)
        {
            throw new NotImplementedException();
        }
    }
}
