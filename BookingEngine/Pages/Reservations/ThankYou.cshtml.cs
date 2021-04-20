using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingEngine.Data;
using BookingEngine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingEngine.Pages.Reservations
{
    public class ThankYouModel : PageModel
    {
        private readonly BookingEngineContext _ctx;
        public ThankYouModel(BookingEngineContext _ctx)
        {
            this._ctx = _ctx;
        }

        [BindProperty]
        public Rooms BookedRoom { get; set; }

        [BindProperty]
        public Guest BookedByGuest { get; set; }

        //[BindProperty]
        //public string Base64Image { get; set; }
        public async Task OnGet(int reservationId)
        {
            var reservation = _ctx.Reservation.Include(res => res.Room)
                .Include(res => res.Guest)
                .FirstOrDefault(r => r.ID == reservationId);
            if (reservation == null)
            {
                return;
            }
            BookedRoom = reservation.Room;
            BookedByGuest = reservation.Guest;
            BookedRoom.Base64Image = $"data:image/png;base64,{Convert.ToBase64String(BookedRoom.ByteArrayImage)}";
        }
    }
}
