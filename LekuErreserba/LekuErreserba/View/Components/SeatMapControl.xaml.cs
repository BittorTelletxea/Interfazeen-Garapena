using LekuErreserba.Models;
using LekuErreserba.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LekuErreserba.View.Components
{
    public partial class SeatMapControl : UserControl
    {
        public SeatMapControl()
        {
            InitializeComponent();
        }

        public MainViewModel? ViewModel { get; set; }

        public void LoadSeats(List<Seat> seats)
        {
            SeatGrid.Children.Clear();
            foreach (var seat in seats)
            {
                var btn = new Button
                {
                    Content = seat.Label,
                    Margin = new Thickness(4),
                    Background = seat.Status == SeatStatus.Available ? Brushes.LightGreen : Brushes.IndianRed,
                    Tag = seat
                };
                btn.Click += (s, e) =>
                {
                    if (ViewModel is not null)
                    {
                        ViewModel.ToggleSeatCommand.Execute(seat);
                        LoadSeats(ViewModel.SelectedZone?.Seats ?? new List<Seat>());
                    }
                };
                SeatGrid.Children.Add(btn);
            }
        }
    }
}
