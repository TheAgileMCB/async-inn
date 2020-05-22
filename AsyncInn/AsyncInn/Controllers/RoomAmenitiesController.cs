using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomAmenitiesController : ControllerBase
    {
        private readonly HotelDbContext _context;

        public RoomAmenitiesController(HotelDbContext context)
        {
            _context = context;
        }

        // GET: api/RoomAmenities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomAmenity>>> GetRoomAmenity()
        {
            return await _context.RoomAmenity.ToListAsync();
        }

        // GET: api/RoomAmenities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomAmenity>> GetRoomAmenity(int id)
        {
            var roomAmenity = await _context.RoomAmenity.FindAsync(id);

            if (roomAmenity == null)
            {
                return NotFound();
            }

            return roomAmenity;
        }

        // PUT: api/RoomAmenities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomAmenity(int id, RoomAmenity roomAmenity)
        {
            if (id != roomAmenity.RoomID)
            {
                return BadRequest();
            }

            _context.Entry(roomAmenity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomAmenityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RoomAmenities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RoomAmenity>> PostRoomAmenity(RoomAmenity roomAmenity)
        {
            _context.RoomAmenity.Add(roomAmenity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RoomAmenityExists(roomAmenity.RoomID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRoomAmenity", new { id = roomAmenity.RoomID }, roomAmenity);
        }

        // DELETE: api/RoomAmenities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RoomAmenity>> DeleteRoomAmenity(int id)
        {
            var roomAmenity = await _context.RoomAmenity.FindAsync(id);
            if (roomAmenity == null)
            {
                return NotFound();
            }

            _context.RoomAmenity.Remove(roomAmenity);
            await _context.SaveChangesAsync();

            return roomAmenity;
        }

        private bool RoomAmenityExists(int id)
        {
            return _context.RoomAmenity.Any(e => e.RoomID == id);
        }
    }
}
