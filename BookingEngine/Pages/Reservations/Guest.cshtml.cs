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
    public class GuestModel : PageModel
    {
        private readonly BookingEngine.Data.BookingEngineContext _context;

        [BindProperty]
        public int RoomId { get; set; }

        [BindProperty]
        public Guest Guest { get; set; }

        [BindProperty]
        public DateTime Checkin { get; set; }

        [BindProperty]
        public DateTime Checkout { get; set; }

        [BindProperty]
        public int NumberOfAdults { get; set; }

        public GuestModel(BookingEngine.Data.BookingEngineContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int roomId, DateTime checkin, DateTime checkout, int numberOfAdults)
        {
            this.RoomId = roomId;

            this.Checkin = checkin;
            this.Checkout = checkout;
            this.NumberOfAdults = numberOfAdults;

            return Page();
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }



            _context.Guest.Add(Guest);



            Reservation reservation = new Reservation
            {
                CheckIn = this.Checkin,
                CheckOut = this.Checkout,
                Guest = Guest,
                RoomId = this.RoomId,
                NumberOfAdults = this.NumberOfAdults
            };
            _context.Reservation.Add(reservation);



            await _context.SaveChangesAsync();



            int guestId = Guest.GuestId;



            return RedirectToPage("./ThankYou", new { reservationId = reservation.ID });



        }
    }
}
