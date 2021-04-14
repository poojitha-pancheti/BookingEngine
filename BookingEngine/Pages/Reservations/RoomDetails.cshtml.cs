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

        public async Task OnGetAsync(int roomId)
        {
            if (roomId == 0)
            {
                return;
            }
            var room = await _context.Rooms.Where(s => s.RoomID == roomId).FirstOrDefaultAsync();

            room.Base64Image = $"data:image/png;base64,{Convert.ToBase64String(room.ByteArrayImage)}";

            Room = room;
        }

    }
}
