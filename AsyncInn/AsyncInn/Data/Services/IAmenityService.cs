using AsyncInn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data.Services
{
    public interface IAmenityService
    {
        Task<IEnumerable<Amenity>> GetAllAmenitys();

        Task<Amenity> GetOneAmenity(int ID);

        Task<bool> UpdateAmenity(int ID, Amenity Amenity);

        Task<Amenity> AddAmenity(Amenity Amenity);

        Task<Amenity> DeleteAmenity(int ID);
    }
}
