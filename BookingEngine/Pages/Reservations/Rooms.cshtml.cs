using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingEngine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingEngine.Pages.Reservations
{
    public class RoomsModel : PageModel
    {
        private readonly BookingEngine.Data.BookingEngineContext _context;

        public RoomsModel(BookingEngine.Data.BookingEngineContext context)
        {
            _context = context;
        }
        public IList<Room> Room { get; set; }
        public async Task OnGetAsync()
        {
            Room = await _context.rooms.ToListAsync();
        }
    }
}
