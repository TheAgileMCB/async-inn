using AsyncInn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data.Services
{
    public class AmenityService : IAmenityService
    {
        public Task<Amenity> AddAmenity(Amenity Amenity)
        {
            throw new NotImplementedException();
        }

        public Task<Amenity> DeleteAmenity(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Amenity>> GetAllAmenitys()
        {
            throw new NotImplementedException();
        }

        public Task<Amenity> GetOneAmenity(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAmenity(int ID, Amenity Amenity)
        {
            throw new NotImplementedException();
        }
    }
}
