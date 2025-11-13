using IkusOsagaiakBittor.Models;
using System.Collections.ObjectModel;

namespace IkusOsagaiakBittor.Models
{
    public class Zone
    {
        public string Name { get; set; }
        public ObservableCollection<Seat> Seats { get; set; } = new ObservableCollection<Seat>();
    }
}
