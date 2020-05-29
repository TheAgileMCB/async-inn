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
using AsyncInn.Models.Api;

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        IRoomRepository roomRepository;

        public RoomsController(IRoomRepository roomService)
        {
            this.roomRepository = roomService;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDTO>>> GetRoom()
        {
            return Ok(await roomRepository.GetAllRooms());
        }

        // GET: api/Rooms/5
        [HttpGet("{ID}")]
        public async Task<ActionResult<RoomDTO>> GetRoom(int ID)
        {
            var room = await roomRepository.GetOneRoom(ID);

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

            bool didUpdate = await roomRepository.UpdateRoom(ID, room);

            if (!didUpdate)
                return NotFound();

            return NoContent();
        }

        // POST: api/Rooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            await roomRepository.AddRoom(room);

            return CreatedAtAction("GetRoom", new { id = room.ID }, room);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{ID}")]
        public async Task<ActionResult<Room>> DeleteRoom(int ID)
        {
            var room = await roomRepository.DeleteRoom(ID);

            return room;
        }
        // POST api/Rooms/5/Amenities/17
        [HttpPost("{roomID}/Amenities/{amenityID}")]
        public async Task<ActionResult> AddRoomAmenity(int roomID, int amenityID)
        {
            await roomRepository.AddAmenityToRoom(roomID, amenityID);
            return NoContent();
        }

        [HttpDelete("{roomID}/Amenity/{amenityID}")]
        public async Task<ActionResult> RemoveRoomAmenity(int roomID, int amenityID)
        {
            await roomRepository.RemoveAmenityFromRoom(roomID, amenityID);
            return NoContent();
        }
    }
}
