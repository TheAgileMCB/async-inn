using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Data.Services;

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        IRoomService roomService;

        public RoomsController(IRoomService roomService)
        {
            this.roomService = roomService;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRoom()
        {
            return Ok(await roomService.GetAllRooms());
            //return await _context.Room.ToListAsync();
        }

        // GET: api/Rooms/5
        [HttpGet("{ID}")]
        public async Task<ActionResult<Room>> GetRoom(int ID)
        {
            var room = await roomService.GetOneRoom(ID);
            //var room = await _context.Room.FindAsync(ID);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{ID}")]
        public async Task<IActionResult> PutRoom(int ID, Room room)
        {
            if (ID != room.ID)
            {
                return BadRequest();
            }

            bool didUpdate = await roomService.UpdateRoom(ID, room);

            if (!didUpdate)
                return NotFound();

            //_context.Entry(room).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!RoomExists(ID))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return NoContent();
        }

        // POST: api/Rooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            await roomService.AddRoom(room);
            //_context.Room.Add(room);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoom", new { id = room.ID }, room);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{ID}")]
        public async Task<ActionResult<Room>> DeleteRoom(int ID)
        {
            var room = await roomService.DeleteRoom(ID);
            //var room = await _context.Room.FindAsync(ID);
            //if (room == null)
            //{
            //    return NotFound();
            //}

            //_context.Room.Remove(room);
            //await _context.SaveChangesAsync();

            return room;
        }

        private bool RoomExists(int ID)
        {
            return _context.Room.Any(e => e.ID == ID);
        }
    }
}
