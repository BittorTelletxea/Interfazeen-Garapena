
using IkusOsagaiakBittor.Models;
using IkusOsagaiakBittor.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace IkusOsagaiakBittor.ViewModels
{
    public class ReservationViewModel : INotifyPropertyChanged
    {
        private readonly ReservationService _reservationService = new ReservationService();

        private string _currentTransportMode;
        private Zone _activeZone;

        public ObservableCollection<string> TransportOptions { get; } =
            new ObservableCollection<string> { "Bus", "Train", "Airplane" };

        public string CurrentTransportMode
        {
            get => _currentTransportMode;
            set
            {
                if (_currentTransportMode != value)
                {
                    _currentTransportMode = value;
                    OnPropertyChanged(nameof(CurrentTransportMode));
                    LoadActiveZone();
                }
            }
        }

        public Zone ActiveZone
        {
            get => _activeZone;
            set
            {
                if (_activeZone != value)
                {
                    _activeZone = value;
                    OnPropertyChanged(nameof(ActiveZone));
                }
            }
        }

        public ICommand ToggleSeatCommand { get; }
        public ICommand ConfirmReservationCommand { get; }
        public ICommand ResetSeatsCommand { get; }

        public ReservationViewModel()
        {
            ToggleSeatCommand = new RelayCommand<Seat>(OnSeatClicked);
            ConfirmReservationCommand = new RelayCommand(ConfirmSelectedSeats);
            ResetSeatsCommand = new RelayCommand(ClearSelectedSeats);

            CurrentTransportMode = TransportOptions[0];
        }

        private void LoadActiveZone()
        {
            ActiveZone = _reservationService.LoadZone(CurrentTransportMode);
        }

        private void OnSeatClicked(Seat seat)
        {
            switch (seat.Status)
            {
                case SeatStatus.Available:
                    seat.Status = SeatStatus.Selected;
                    break;
                case SeatStatus.Selected:
                    seat.Status = SeatStatus.Available;
                    break;
            }

            _reservationService.SaveAllZones();
        }

        private void ConfirmSelectedSeats()
        {
            foreach (var seat in ActiveZone.Seats)
            {
                if (seat.Status == SeatStatus.Selected)
                {
                    seat.Status = SeatStatus.Reserved;
                    seat.ReservedFor = DateTime.Now;
                }
            }

            _reservationService.SaveAllZones();
            OnPropertyChanged(nameof(ActiveZone));
        }

        private void ClearSelectedSeats()
        {
            foreach (var seat in ActiveZone.Seats)
            {
                if (seat.Status == SeatStatus.Selected || seat.Status == SeatStatus.Reserved)
                {
                    seat.Status = SeatStatus.Available;
                    seat.ReservedFor = null;
                }
            }

            _reservationService.SaveAllZones();
            OnPropertyChanged(nameof(ActiveZone));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
