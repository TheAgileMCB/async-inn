using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Web.Models.Services
{
    public interface IHotelService
    {
        Task<List<Hotel>> GetAll();
        Task<Hotel> GetOne(int id);
    }
}
