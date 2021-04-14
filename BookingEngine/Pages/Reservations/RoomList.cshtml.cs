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

        public IList<Rooms> Rooms { get;set; }

        public async Task OnGetAsync()
        {
            var rooms = await _context.Rooms.ToListAsync();
            foreach (var room in rooms)
            {
                room.Base64Image = $"data:image/png;base64,{Convert.ToBase64String(room.ByteArrayImage)}";
            }
            Rooms = rooms;
        }
    }
}
