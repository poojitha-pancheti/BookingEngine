using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookingEngine.Data;
using BookingEngine.Models;

namespace BookingEngine.Pages.Reservations
{
    public class AdministrationModel : PageModel
    {
        private readonly BookingEngine.Data.BookingEngineContext _context;

        public AdministrationModel(BookingEngine.Data.BookingEngineContext context)
        {
            _context = context;
        }

        public IList<Reservation> Reservation { get;set; }

        public async Task OnGetAsync()
        {
            Reservation = await _context.Reservation
                .Include(r => r.Guest)
                .Include(r => r.Room).ToListAsync();
        }
    }
}
