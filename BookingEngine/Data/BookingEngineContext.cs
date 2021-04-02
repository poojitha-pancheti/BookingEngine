using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookingEngine.Models;

namespace BookingEngine.Data
{
    public class BookingEngineContext : DbContext
    {
        public BookingEngineContext (DbContextOptions<BookingEngineContext> options)
            : base(options)
        {
        }         
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<Guest> guests { get; set; }
    }
}
