using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingEngine.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public string Description { get; set; }
        public byte[] Images { get; set; }
        public double Price { get; set; }
        public double Taxes { get; set; }
        public double TotalPrice { get; set; }
    }
}
