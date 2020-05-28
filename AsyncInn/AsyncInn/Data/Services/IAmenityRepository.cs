using AsyncInn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data.Services
{
    public interface IAmenityRepository
    {
        Task<IEnumerable<Amenity>> GetAllAmenities();

        Task<Amenity> GetOneAmenity(int ID);

        Task<bool> UpdateAmenity(int ID, Amenity amenity);

        Task<Amenity> AddAmenity(Amenity amenity);

        Task<Amenity> DeleteAmenity(int ID);
    }
}
