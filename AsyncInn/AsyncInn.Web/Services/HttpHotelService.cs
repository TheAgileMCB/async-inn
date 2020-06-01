using AsyncInn.Web.Models;
using AsyncInn.Web.Models.Services;
using System.Text.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AsyncInn.Web.Controllers;
using Microsoft.AspNetCore.WebUtilities;

namespace AsyncInn.Web
{
    public class HttpHotelService : IHotelService
    {
        private readonly HttpClient client;

        public HttpHotelService(HttpClient client)
        {
            this.client = client;
        }
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

        public async Task<Hotel> Create(Hotel hotel)
        {
            using (var content = new StringContent(JsonSerializer.Serialize(hotel), System.Text.Encoding.UTF8, "application/json"))
            {
                var response = await client.PostAsync("Hotels", content);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var responseStream = response.Content.ReadAsStreamAsync().Result;
                    Hotel result = await JsonSerializer.DeserializeAsync<Hotel>(responseStream);
                    return result;
                }
                //string returnValue = result.Content.ReadAsStringAsync().Result;
                throw new System.Exception($"Failed to POST data: ({response.StatusCode})");
            }
        }
    }
}