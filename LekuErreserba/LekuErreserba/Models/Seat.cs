using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LekuErreserba.Models
{ 
    public enum SeatStatus { Available, Reserved }

    public class Seat
    {
        public int Id { get; set; }
        public string Label { get; set; } = "";
        public SeatStatus Status { get; set; } = SeatStatus.Available;
    }
}
