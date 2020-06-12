using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data;
using AsyncInn.Data.Services;
using AsyncInn.Models;
using AsyncInn.Models.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        IHotelRepository hotelRepository;

        public HotelsController(IHotelRepository hotelRepository)
        {
            this.hotelRepository = hotelRepository;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotel()
        {
            return Ok(await hotelRepository.GetAllHotels());
        }

        // GET: api/Hotels/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<HotelDTO>> GetHotel(int ID)
        {
            HotelDTO hotel = await hotelRepository.GetOneHotel(ID);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }

        // PUT: api/Hotels/1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int ID, Hotel hotel)
        {
            if (ID != hotel.ID)
            {
                return BadRequest();
            }

            bool didUpdate = await hotelRepository.UpdateHotel(ID, hotel);

            if (!didUpdate)
                return NotFound();

            return NoContent();
        }

        // POST: api/Hotel
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            await hotelRepository.AddHotel(hotel);

            return CreatedAtAction("GetHotel", new { id = hotel.ID }, hotel);
        }

        // DELETE: api/Hotel/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hotel>> DeleteHotel(int ID)
        {
            var hotel = await hotelRepository.DeleteHotel(ID);

            return hotel;
        }
        //[HttpGet("{hotelID}/Rooms")]
        //public async Task<ActionResult<IEnumerable<HotelRoomDTO>>> GetHotelRooms(int hotelID)
        //{
        //    var rooms = await HotelRepository.GetHotelRooms(hotelID);
        //    return rooms;
        //}
    }
}
