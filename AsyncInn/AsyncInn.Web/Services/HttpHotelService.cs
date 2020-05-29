using AsyncInn.Web.Models;
using AsyncInn.Web.Models.Services;
using System.Text.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncInn.Web
{
    public class HttpHotelService : IHotelService
    {
        private static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new System.Uri("https://localhost:5001/api/"),
        };
        public async Task<List<Hotel>> GetAll()
        {
            var responseStream = await client.GetStreamAsync("Hotels");
            List<Hotel> result = await JsonSerializer.DeserializeAsync<List<Hotel>>(responseStream);
            return result;
        }

        public async Task<Hotel> GetOne(int id)
        {
            var responseStream = await client.GetStreamAsync($"Hotels/{id}");
            Hotel result = await JsonSerializer.DeserializeAsync<Hotel>(responseStream);
            return result;
        }
    }
}