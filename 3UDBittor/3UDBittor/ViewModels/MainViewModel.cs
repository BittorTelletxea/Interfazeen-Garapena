using _3UDBittor.Models;
using _3UDBittor.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _3UDBittor.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ReservationService _service = new ReservationService();

        private string _selectedMode;
        private Zone _currentZone;

        public ObservableCollection<string> TransportModes { get; set; } =
            new ObservableCollection<string> { "Bus", "Train", "Airplane" };

        public string SelectedMode
        {
            get => _selectedMode;
            set
            {
                if (_selectedMode != value)
                {
                    _selectedMode = value;
                    OnPropertyChanged(nameof(SelectedMode));
                    LoadCurrentZone();
                }
            }
        }

        public Zone CurrentZone
        {
            get => _currentZone;
            set
            {
                if (_currentZone != value)
                {
                    _currentZone = value;
                    OnPropertyChanged(nameof(CurrentZone));
                }
            }
        }

        public ICommand SeatClickCommand { get; }
        public ICommand ReserveCommand { get; }
        public ICommand CancelCommand { get; }

        public MainViewModel()
        {
            SeatClickCommand = new RelayCommand<Seat>(ToggleSeatSelection);
            ReserveCommand = new RelayCommand(ReserveSelectedSeats);
            CancelCommand = new RelayCommand(CancelSelectedSeats);

            SelectedMode = TransportModes[0];
        }

        private void LoadCurrentZone()
        {
            CurrentZone = _service.LoadZone(SelectedMode);
        }

        private void ToggleSeatSelection(Seat seat)
        {
            if (seat.Status == SeatStatus.Available)
                seat.Status = SeatStatus.Selected;
            else if (seat.Status == SeatStatus.Selected)
                seat.Status = SeatStatus.Available;

            _service.SaveAllZones();
        }

        private void ReserveSelectedSeats()
        {
            foreach (var seat in CurrentZone.Seats)
            {
                if (seat.Status == SeatStatus.Selected)
                {
                    seat.Status = SeatStatus.Reserved;
                    seat.ReservedFor = DateTime.Now;
                }
            }

            _service.SaveAllZones();

            OnPropertyChanged(nameof(CurrentZone));
        }

        private void CancelSelectedSeats()
        {
            foreach (var seat in CurrentZone.Seats)
            {
                if (seat.Status == SeatStatus.Selected || seat.Status == SeatStatus.Reserved)
                {
                    seat.Status = SeatStatus.Available;
                    seat.ReservedFor = null;
                }
            }

            _service.SaveAllZones();

            OnPropertyChanged(nameof(CurrentZone));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
