using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookingEngine.Data;
using BookingEngine.Models;

namespace BookingEngine.Pages.Reservations
{
    public class CreateModel : PageModel
    {
        private readonly BookingEngine.Data.BookingEngineContext _context;

        public CreateModel(BookingEngine.Data.BookingEngineContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            TodaysDate = DateTime.Today.ToString("yyyyy-MM-dd");
            return Page();
        }

        [BindProperty]
        public Reservation Reservation { get; set; }

        [BindProperty]
        public string TodaysDate { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }



            return RedirectToPage("./RoomList", new
            {
                CheckIn = Reservation.CheckIn,
                CheckOut = Reservation.CheckOut,
                NumberOfAdults = Reservation.NumberOfAdults
            });
        }
    }
}
