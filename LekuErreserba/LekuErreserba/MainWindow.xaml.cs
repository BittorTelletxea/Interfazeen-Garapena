using LekuErreserba.Models;
using LekuErreserba.ViewModels;
using System.Collections.Generic;
using System.Windows;

namespace LekuErreserba
{
    public partial class MainWindow : Window
    {
        private MainViewModel vm;

        public MainWindow()
        {
            InitializeComponent();

            vm = new MainViewModel();
            DataContext = vm;

            // Asignar el ViewModel al control y cargar los asientos
            SeatMapView.ViewModel = vm;
            SeatMapView.LoadSeats(vm.SelectedZone?.Seats ?? new List<Seat>());

            // Recargar asiento al cambiar de zona
            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(vm.SelectedZone))
                {
                    SeatMapView.LoadSeats(vm.SelectedZone?.Seats ?? new List<Seat>());
                }
            };
        }
    }
}
