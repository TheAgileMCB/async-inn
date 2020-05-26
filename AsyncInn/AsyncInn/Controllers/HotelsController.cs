using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data;
using AsyncInn.Data.Services;
using AsyncInn.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        IHotelService hotelService;

        public HotelsController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        // GET: api/Hotel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotel()
        {
            return Ok(await hotelService.GetAllHotels());
        }

        // GET: api/Hotel/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Hotel>> GetHotel(int ID)
        {
            var hotel = await hotelService.GetOneHotel(ID);

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

            bool didUpdate = await hotelService.UpdateHotel(ID, hotel);

            if (!didUpdate)
                return NotFound();

            

            return NoContent();
        }

        // POST: api/Hotel
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            await hotelService.AddHotel(hotel);

            return CreatedAtAction("GetHotel", new { id = hotel.ID }, hotel);
        }

        // DELETE: api/Hotel/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hotel>> DeleteHotel(int ID)
        {
            var hotel = await hotelService.DeleteHotel(ID);
            //var hotel = await _context.Hotel.FindAsync(ID);
            if (hotel == null)
            {
                return NotFound();
            }

            //_context.Hotel.Remove(hotel);
            //await _context.SaveChangesAsync();

            return hotel;
        }

        
    }
}
