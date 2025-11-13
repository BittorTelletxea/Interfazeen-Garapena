using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3UDBittor.Models
{
    public enum SeatStatus { Available, Selected, Reserved }

    public class Seat : INotifyPropertyChanged
    {
        private SeatStatus _status;
        private DateTime? _reservedFor;

        public string Id { get; set; }

        public SeatStatus Status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        public DateTime? ReservedFor
        {
            get => _reservedFor;
            set
            {
                if (_reservedFor != value)
                {
                    _reservedFor = value;
                    OnPropertyChanged(nameof(ReservedFor));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
