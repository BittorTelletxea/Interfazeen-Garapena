using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LekuErreserba.Models
{
     public enum TransportType { Bus, Train, Plane }

    public class Zone
    {
        public string Name { get; set; } = "";
        public TransportType Transport { get; set; }
        public List<Seat> Seats { get; set; } = new();
    }
}
