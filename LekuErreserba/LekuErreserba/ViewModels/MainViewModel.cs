using LekuErreserba;
using LekuErreserba.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LekuErreserba.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
{
    private readonly ReservationService reservationService = new();
    private Zone? selectedZone;

    public ObservableCollection<Zone> Zones { get; set; }
    public Zone? SelectedZone
    {
        get => selectedZone;
        set
        {
            selectedZone = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand ChangeZoneCommand { get; }
    public RelayCommand ToggleSeatCommand { get; }

    public MainViewModel()
    {
        Zones = new ObservableCollection<Zone>(reservationService.LoadZones());
        SelectedZone = Zones.FirstOrDefault();

        ChangeZoneCommand = new RelayCommand(z =>
        {
            SelectedZone = z as Zone;
        });

        ToggleSeatCommand = new RelayCommand(s =>
        {
            if (s is Seat seat)
            {
                seat.Status = seat.Status == SeatStatus.Available ? SeatStatus.Reserved : SeatStatus.Available;
                reservationService.SaveZones(Zones.ToList());
                OnPropertyChanged(nameof(SelectedZone));
            }
        });
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
}
