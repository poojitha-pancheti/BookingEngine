using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingEngine.Models
{
    public class Reservation
    {
        [Key]
        public int ID { get; set; }
        public int RoomId { get; set; }
        public int GuestId { get; set; }

        [DataType(DataType.Date)]
        public DateTime CheckIn { get; set; }

        [DataType(DataType.Date)]
        public DateTime CheckOut { get; set; }
        public int NumberOfAdults { get; set; }
        public virtual Rooms Room { get; set; }
        public virtual Guest Guest { get; set; }
    }
}
