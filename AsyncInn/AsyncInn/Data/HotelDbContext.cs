using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using.AsyncInn.Models;

namespace AsyncInn.Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<HotelRoom>()
                .HasKey(hotelRoom => new
                {
                    hotelRoom.HotelID,
                    hotelRoom.RoomNumber,
                });
        }

    
        public DbSet<Hotel> Hotel { get; set; }
    public DbSet<Room> Room { get; set; }
}
}
