using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3UDBittor.Models
{
    public class Zone
    {
        public string Name { get; set; }
        public ObservableCollection<Seat> Seats { get; set; } = new ObservableCollection<Seat>();
    }
}
