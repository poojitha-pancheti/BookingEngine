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
    public class RoomDetailsModel : PageModel
    {
        private readonly BookingEngine.Data.BookingEngineContext _context;

        public RoomDetailsModel(BookingEngine.Data.BookingEngineContext context)
        {
            _context = context;
        }

        public Rooms Room { get; set; }
        [BindProperty]
        public DateTime CheckIn { get; set; }
        [BindProperty]
        public DateTime CheckOut { get; set; }
        [BindProperty]
        public int NumberOfAdults { get; set; }

        public async Task OnGetAsync(int roomId, DateTime checkIn, DateTime checkOut,int numberOfAdults)
        {
            if (roomId == 0)
            {
                return;
            }
            this.CheckIn = checkIn;
            this.CheckOut = checkOut;
            this.NumberOfAdults = numberOfAdults;

            var room = await _context.Rooms.Where(s => s.RoomID == roomId).FirstOrDefaultAsync();

            room.Base64Image = $"data:image/png;base64,{Convert.ToBase64String(room.ByteArrayImage)}";

            Room = room;
        }

    }
}
