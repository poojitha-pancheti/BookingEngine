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
    public class RoomListModel : PageModel
    {
        private readonly BookingEngine.Data.BookingEngineContext _context;

        public RoomListModel(BookingEngine.Data.BookingEngineContext context)
        {
            _context = context;
        }

        public IList<Rooms> Rooms { get; set; }

        [BindProperty]
        public DateTime CheckIn { get; set; }
        [BindProperty]
        public DateTime CheckOut { get; set; }
        [BindProperty]
        public int NumberOfAdults { get; set; }

        public async Task OnGetAsync(DateTime checkIn, DateTime checkOut, int numberOfAdults)
        {
            this.CheckIn = checkIn;
            this.CheckOut = checkOut;
            this.NumberOfAdults = numberOfAdults;

            var bookedRoomIds = await _context.Reservation
                .Where(r => CheckIn <= r.CheckIn && r.CheckOut <= CheckOut)
                .Select(x => x.RoomId)
                .ToListAsync();

            var rooms = await _context.Rooms
                .Where(r=>bookedRoomIds.Contains(r.RoomID)==false)
                .ToListAsync();
            foreach (var room in rooms)
            {
                room.Base64Image = $"data:image/png;base64,{Convert.ToBase64String(room.ByteArrayImage)}";
            }
            Rooms = rooms;
        }
    }
}
